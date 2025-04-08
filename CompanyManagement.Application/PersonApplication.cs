using AccountManagement.Infrastructure.EFCore.Repository;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Domain.LicenceCategoryAgg;
using Framework.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application
{
       
    public  class PersonApplication :IPersonApplication
        
    {
        private readonly IPersonRepository personRepository;
        private readonly ILogger<ChecklistApplication> _logger;

        public PersonApplication(IPersonRepository personRepository, ILogger<ChecklistApplication> logger)
        {
            this.personRepository = personRepository;
            _logger = logger;
        }

        public OperationResult Create(CreatePeopleCompany command)
        {
            var operation = new OperationResult();

            // چک کردن خالی بودن نام یا برند شرکت
            if (string.IsNullOrWhiteSpace(command.NamePeopleCo) || (command.CompanyId == null))
            {
                operation.Failed("نام فرد و یا نام شرکت نباید خالی باشد");
                return operation;
            }
           


            //var people = command.People.Select(p => new Person
            //{
            //    NamePeopleCo = p.NamePeopleCo,
            //    RspponsePeopleCo = p.RspponsePeopleCo,
            //    PhonePeopleCo = p.PhonePeopleCo,


            //}).ToList();

            var person = new Person(command.NamePeopleCo, command.RspponsePeopleCo, command.PhonePeopleCo, command.CompanyId );

            try
            {
                personRepository.Create(person);
                personRepository.SaveChanges();
                return operation.Succeeded(ApplicationMessages.SuccessMessage);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "خطا در ذخیره سازی");
                return operation.Failed("مشکلی در ذخیره‌سازی داده‌ها وجود دارد.");
            }


            operation.Succeeded("عملیات با موفقیت انجام گردید");
            return operation;
        }

        public List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return personRepository.SerachTotal(searchModel, provincialAdminStateCategoryId);
        }
    }
}
