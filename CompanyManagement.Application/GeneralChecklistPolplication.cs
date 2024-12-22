using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;

namespace CompanyManagement.Application
{
  

    public class GeneralChecklistPolplication : IGeneralChecklistPolApplication
    {

        private readonly IGeneralChecklistPolicyRepository _generalChecklistPolicyRepository;

        public GeneralChecklistPolplication(IGeneralChecklistPolicyRepository generalChecklistPolicyRepository)
        {
            _generalChecklistPolicyRepository = generalChecklistPolicyRepository;
        }

        public EditCheckGenPol Getdetails(long id)
        {
            return _generalChecklistPolicyRepository.Getdetails(id);
        }
    }
}
