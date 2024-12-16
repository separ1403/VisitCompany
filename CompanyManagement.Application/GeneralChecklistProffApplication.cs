using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using CompanyManagement.Domain.ChecklistAgg;
using CompanyManagement.Infrasructure.EFCore.Repository;

namespace CompanyManagement.Application
{

    public class GeneralChecklistProffApplication : IGeneralChecklistProffApplication
    {
        private readonly IGeneralChecklistProffesionalRepository _generalChecklistProffesionalRepository;

        public GeneralChecklistProffApplication(IGeneralChecklistProffesionalRepository generalChecklistProffesionalRepository)
        {
            _generalChecklistProffesionalRepository = generalChecklistProffesionalRepository;
        }

        public EditCheckGenpro Getdetails(long id)
        {
            return _generalChecklistProffesionalRepository.Getdetails(id);
        }
    }
}

