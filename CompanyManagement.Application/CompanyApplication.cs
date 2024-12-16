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

namespace CompanyManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        public CompanyApplication(ICompanyRepository companyRepository, IAccountRepository accountRepository, ILicenceCategoryRepository licenceCategoryRepository)
        {
            _companyRepository = companyRepository;
            _accountRepository = accountRepository;
            _licenceCategoryRepository = licenceCategoryRepository;
        }


        private readonly ICompanyRepository _companyRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILicenceCategoryRepository _licenceCategoryRepository;




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
            var company = new Company(command.CompanyName, command.Brand, command.ManagerName, command.SecurityManagerName, command.PhoneNumber, command.Description, command.NationalCode,command.Address, command.CategoryId, command.LicenceIds, command.AccountIds,command.Doamin, referDateFrom, referDateTo,command.StateCategoryId);


            company.AddAccounts(accounts);
            company.AddLicence(licences);

            _companyRepository.Create(company);
            _companyRepository.SaveChanges();

            operation.Succeeded("عملیات با موفقیت انجام گردید");
            return operation;
        }



        public OperationResult Edit(EditCompany command)
        {
            var operation = new OperationResult();

            var company = _companyRepository.Get(command.Id);

            if (company == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
                return operation;
            }
            var referDateFrom = command.ReferDateFrom.ToGeorgianDateTime();
            var referDateTo = command.ReferDateTo.ToGeorgianDateTime();
            company.Edit(command.CompanyName, command.Brand, command.ManagerName,
                command.SecurityManagerName,
                command.PhoneNumber, command.Description, command.NationalCode,command.Address,
                command.CategoryId, command.LicenceIds,command.AccountIds,command.Doamin , referDateFrom, referDateTo,command.StateCategoryId);


            _companyRepository.SaveChanges();

            operation.Succeeded(ApplicationMessages.SuccessMessage);
            return operation;
        }
public OperationResult BatchEdit(BatchEditCompany command)
{
    var operation = new OperationResult();

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
                company.Edit(command.CompanyName, command.Brand, command.ManagerName,
                     command.SecurityManagerName, command.PhoneNumber, command.Description,
                     command.NationalCode, command.Address, command.CategoryId,
                     command.LicenceIds, command.AccountIds, command.Doamin,
                     referDateFrom, referDateTo,command.StateCategoryId);
    }

    _companyRepository.SaveChanges();

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
    }
}
