using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application
{
    public class GeneralChecklistApplication : IGeneralChecklistApplication
    {
        private readonly IGeneralChecklistRepository _generalChecklistRepository;

        public GeneralChecklistApplication(IGeneralChecklistRepository generalChecklistRepository)
        {
            _generalChecklistRepository = generalChecklistRepository;
        }

        public EditGeneralChecklist Getdetails(long id)
        {
            return _generalChecklistRepository.Getdetails(id);
        }

        public List<(string PropertyName, long TotalScore)> GetMostVulnerableProperties()



        {
            return _generalChecklistRepository.GetMostVulnerableProperties();
        }
    }
}
