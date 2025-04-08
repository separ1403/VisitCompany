using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using CompanyManagement.Application.Contract.LicenceCategory;
using CompanyManagement.Domain.ChecklistAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CompanyManagement.Infrasructure.EFCore.Migrations;
using CompanyManagement.Infrasructure.EFCore.Repository;

namespace CompanyManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        

        private readonly ICompanyRepository _companyRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILicenceCategoryRepository _licenceCategoryRepository;
        private readonly IApiService _apiService;
        private readonly ILogger<CompanyApplication> _logger;

        public CompanyApplication(ICompanyRepository companyRepository, IAccountRepository accountRepository, ILicenceCategoryRepository licenceCategoryRepository, IApiService apiService, ILogger<CompanyApplication> logger)
        {
            _companyRepository = companyRepository;
            _accountRepository = accountRepository;
            _licenceCategoryRepository = licenceCategoryRepository;
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<OperationResult> EditRasmio(long id)
        {
            var operation = new OperationResult();
            var company = _companyRepository.Get(id);

            if (company == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }

            var apiResponse = await _apiService.GetCompanyDetailsAsync(company.NationalCode);

            //if (apiResponse != null)
            //{

            //       EditCompany command = new EditCompany();
            //    command.TitleRasm = apiResponse.Title;
            //    command.RegistrationDateRasm = apiResponse.RegistrationDate;
            //    command.RegistrationNoRasm = apiResponse.RegistrationNo;
            //    command.CapitalRasm = apiResponse.Capital;
            //    command.AddressRasm = apiResponse.Address;
            //    command.TaxNumberRasm = apiResponse.TaxNumber;
            //    command.PostalCodeRasm = apiResponse.PostalCode;
            //    command.LastUpdateRasm = apiResponse.LastUpdate;
            //    command.StatusRasm = apiResponse.Status;
            //    command.EdareKolRasm = apiResponse.EdareKol;
            //    command.VahedSabtiRasm = apiResponse.VahedSabti;

            //    company.EditRasmio(command.TitleRasm,
            //   command.RegistrationDateRasm, command.RegistrationNoRasm, command.CapitalRasm ?? 0
            //        , command.AddressRasm, command.TaxNumberRasm, command.PostalCodeRasm, command.LastUpdateRasm,
            //        command.StatusRasm, command.EdareKolRasm, command.VahedSabtiRasm);


            //به خاطر بهینه سازی کد بالا که طولانی هم بود تبدیل شد به کد پایین
            if (apiResponse == null)
                return operation.Failed("اطلاعاتی از سامانه ثبت شرکت‌ها دریافت نشد.");

            company.EditRasmio(
        apiResponse.Title,
        apiResponse.RegistrationDate,
        apiResponse.RegistrationNo,
        apiResponse.Capital ?? 0,
        apiResponse.Address,
        apiResponse.TaxNumber,
        apiResponse.PostalCode,
        apiResponse.LastUpdate,
        apiResponse.Status,
        apiResponse.EdareKol,
        apiResponse.VahedSabti
    );

            try
            {
                await _companyRepository.SaveChangesAsync();
                return operation.Succeeded(ApplicationMessages.SuccessMessage);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ویرایش اطلاعات رسمی شرکت (EditRasmio) برای CompanyId={CompanyId}", id);
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }
        }

        public OperationResult Create(CreateCompany command)
        {
            var operation = new OperationResult();
            // چک کردن خالی بودن نام یا برند شرکت
            if (string.IsNullOrWhiteSpace(command.CompanyName) || string.IsNullOrWhiteSpace(command.Brand))
            {
                operation.Failed("نام یا برند شرکت نباید خالی باشد");
                return operation;
            }

            // چک کردن تکراری بودن رکورد فقط در صورتی که مقادیر ورودی معتبر باشند
            if (_companyRepository.Exists(x => x.CompanyName == command.CompanyName || x.Brand == command.Brand))
            {
                operation.Failed(ApplicationMessages.DuplicatedRecordCompany);
                return operation;
            }
            DateTime referDateFrom = DateTime.MinValue;
            DateTime referDateTo = DateTime.MinValue;

            if (!string.IsNullOrEmpty(command.ReferDateFrom))
            {
                referDateFrom = command.ReferDateFrom.ToGeorgianDateTime();
            }

            if (!string.IsNullOrEmpty(command.ReferDateTo))
            {
                referDateTo = command.ReferDateTo.ToGeorgianDateTime();
            }

            var accounts = _accountRepository.GetAccountsByIds(command.AccountIds);
            var licences = _licenceCategoryRepository.GetLicenceByIds(command.LicenceIds);

            var people = command.People.Select(p => new Person
            {
                NamePeopleCo = p.NamePeopleCo,
                RspponsePeopleCo = p.RspponsePeopleCo,
                PhonePeopleCo = p.PhonePeopleCo,
              

            }).ToList();

            var company = new Company(command.CompanyName, command.Brand, command.ManagerName, command.SecurityManagerName,
                command.PhoneNumber, command.Description, command.NationalCode,command.Address, command.CategoryId,
                command.LicenceIds, accounts, command.Doamin, referDateFrom, referDateTo,command.StateCategoryId, 
                people, command.CountEmployees ?? 0,command.CountFolowers ?? 0, command.PostalCode, command.TitleRasm, command.RegistrationDateRasm,
                command.RegistrationNoRasm,command.CapitalRasm ?? 0,command.AddressRasm,command.TaxNumberRasm,command.PostalCodeRasm,
                command.LastUpdateRasm,command.StatusRasm,command.EdareKolRasm,command.VahedSabtiRasm);

            //  Console.WriteLine($"CheklistId: {people.CheklistId}");
            company.AddAccounts(accounts);
            company.AddLicence(licences);


            try
            {
                _companyRepository.Create(company);
                _companyRepository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ایجاد شرکت  جدید.");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }
          

            operation.Succeeded("عملیات با موفقیت انجام گردید");
            return operation;
        }


        public OperationResult Edit(EditCompany command)
        {
            var operation = new OperationResult();

            var company = _companyRepository.GetWithAccounts(command.Id); // برای اینکه حتما اکانت ها را هم بیاورد این متد فراخوانی شده است

            if (company == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }

            var referDateFrom = command.ReferDateFrom.ToGeorgianDateTime();
            var referDateTo = command.ReferDateTo.ToGeorgianDateTime();

            var accounts = _accountRepository.GetAccountsByIds(command.AccountIds); // ✅ حساب‌های جدید انتخاب‌شده

            company.Edit(command.CompanyName, command.Brand, command.ManagerName,
                command.SecurityManagerName,
                command.PhoneNumber, command.Description, command.NationalCode, command.Address,
                command.CategoryId, command.LicenceIds, accounts, command.Doamin,
                referDateFrom, referDateTo, command.StateCategoryId, command.PeopleIds,
                command.CountEmployees ?? 0, command.CountFolowers ?? 0, command.PostalCode, checkDate: null);


            try
            {
                _companyRepository.SaveChanges();
                operation.Succeeded(ApplicationMessages.SuccessMessage);


                //_companyRepository.SaveChanges();
            }


            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ویرایش .");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }



            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }



        public OperationResult BatchEdit(BatchEditCompany command)
{
    var operation = new OperationResult();

    var accounts = _accountRepository.GetAccountsByIds(command.AccountIds);


            // بررسی خالی یا مقداردهی نشده بودن CompanyIds
            if (command.CompanyIds == null || !command.CompanyIds.Any())
    {
        operation.Failed("هیچ شرکتی انتخاب نشده است.");
        return operation;
    }

    foreach (var companyId in command.CompanyIds)
    {
        var company = _companyRepository.Get(companyId);

        if (company == null)
        {
            operation.Failed(ApplicationMessages.RecordNotFound);
            return operation;
        }
                var referDateFrom = command.ReferDateFrom.ToGeorgianDateTime();
                var referDateTo = command.ReferDateTo.ToGeorgianDateTime();
                var checkDate = DateTime.Now;
                company.Edit(command.CompanyName, command.Brand, command.ManagerName,
                     command.SecurityManagerName, command.PhoneNumber, command.Description,
                     command.NationalCode, command.Address, command.CategoryId,
                     command.LicenceIds, accounts , command.Doamin,
                     referDateFrom, referDateTo,command.StateCategoryId, command.PeopleIds, command.CountEmployees ?? 0, command.CountFolowers ?? 0, command.PostalCode, checkDate);
    }



            try
            {
                _companyRepository.SaveChanges();
                operation.Succeeded(ApplicationMessages.SuccessMessage);


            }


            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ویرایش .");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }


    operation.Succeeded(ApplicationMessages.SuccessMessage);
    return operation;
}


        

        public List<CompanyViewModel> GetCompenies()
        {
          return  _companyRepository.GetCompenies();
        }

        public List<CompanyViewModel> GetCompeniesWithUsername()
        {
            return _companyRepository.GetCompeniesWithUsername();
        }

        public List<CompanyViewModel> GetCompaniesByCategoryId(int categoryId)
        {
            return _companyRepository.GetCompaniesByCategoryId(categoryId);
        }


        public EditCompany Getdetails(long id)
        {
            return _companyRepository.Getdetails(id);
        }

        public CompanyViewModel Getdetailpartial(long id)
        {
            return _companyRepository.GetdetailPartialview(id);
        }


        public List<CompanyViewModel> Serach(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
           return _companyRepository.Serach(searchModel, provincialAdminStateCategoryId);
        }

        public List<CompanyViewModel> GetCompaniesByLicenceId(int licenceId)
        {
            return _companyRepository.GetCompaniesByLicenceId(licenceId);
        }

        public List<CompanyViewModel> SerachTotal(CompanySearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return _companyRepository.SerachTotal(searchModel, provincialAdminStateCategoryId);
        }

         public List<CompanyViewModel> SerachByAccount(CompanySearchModel searchModel, long? currentUserId = null)
        {
            return _companyRepository.SerachByAccount(searchModel, currentUserId);
        }
    }
}
