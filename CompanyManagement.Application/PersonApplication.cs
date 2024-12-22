using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.AccountAgg;
using CompanyManagement.Domain.ChecklistAgg;
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

        public List<PersonViewModel> SerachTotal(PersonSearchModel searchModel, long? provincialAdminStateCategoryId = null)
        {
            return personRepository.SerachTotal(searchModel, provincialAdminStateCategoryId);
        }
    }
}
