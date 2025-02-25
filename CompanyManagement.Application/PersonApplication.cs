using AccountManagement.Infrastructure.EFCore.Repository;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Application.Contract.Company;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
using Framework.Application;
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

        public PersonApplication(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
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

       

            personRepository.Create(person);
            personRepository.SaveChanges();

            operation.Succeeded("عملیات با موفقیت انجام گردید");
            return operation;
        }

        public List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return personRepository.SerachTotal(searchModel, provincialAdminStateCategoryId);
        }
    }
}
