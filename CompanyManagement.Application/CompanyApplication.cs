using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.CompanyAgg;
using CompanyManagement.Domain.CompanyCategoryAgg;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.AccountAgg;

namespace CompanyManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        public CompanyApplication(ICompanyRepository companyRepository, IAccountRepository accountRepository)
        {
            _companyRepository = companyRepository;
            _accountRepository = accountRepository;
        }

        private readonly ICompanyRepository _companyRepository;
        private readonly IAccountRepository _accountRepository;



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

            var accounts = _accountRepository.GetAccountsByIds(command.AccountIds);
            var company = new Company(command.CompanyName, command.Brand, command.ManagerName, command.SecurityManagerName, command.PhoneNumber, command.Description, command.NationalCode, command.CategoryId, command.LicenceId, command.AccountIds);

            company.AddAccounts(accounts);

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


            //if (_companyRepository.Exists(x => x.CompanyName == command.CompanyName && x.Id != command.Id))
            //{
            //    operation.Failed(ApplicationMessages.DuplicatedRecord);
            //    return operation;
            //}  
            // badan baraye multipage methode edit methode dige benevisam va in ro bezaram baraye multipage

                company.Edit(command.CompanyName, command.Brand, command.ManagerName,
                command.SecurityManagerName,
                command.PhoneNumber, command.Description, command.NationalCode,
                command.CategoryId, command.LicenceId,command.AccountIds);

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


        public EditCompany Getdetails(long id)
        {
            return _companyRepository.Getdetails(id);
        }

        
       

        public List<CompanyViewModel> Serach(CompanySearchModel searchModel)
        {
           return _companyRepository.Serach(searchModel);
        }
    }
}
