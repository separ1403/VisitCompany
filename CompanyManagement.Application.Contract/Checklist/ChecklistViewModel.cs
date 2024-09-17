using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public class ChecklistViewModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
//      public string Description { get;  set; }
        public string NamePeopleCo { get; set; } 
        public string RspponsePeopleCo { get; set; }
        public string PhonePeopleCo { get;  set; }
        public long? CountEmployees { get;  set; } 
        public long? CountFolowers { get;  set; }

        public long? CompanyId { get;  set; }
        public string Company { get; set; }
        public string CreattionDate { get; set; }
        public List<long>? AccountId { get;  set; }
        public string? Accounts { get; set; }

        public long AccountCount { get;  set; } // har nafar che tedad checklist anjam dade

        public double AverageGeneral { get; set; }

        public double AverageProfessional { get; set; }

        public DateTime CalDate { get; set; }
        //junior
        public string IsRootLoginDisableddescription { get; set; }
        public string IsPasswordRecoveryDisableddescription { get; set; }
        public string IsAuxiliaryPortDisableddescription { get; set; }
        public string IsRootLoginAuxDisableddescription { get; set; }
        public string IsDiagnosticPortDisableddescription { get; set; }
        public string IsUSBPortDisableddescription { get; set; }
        public string IsCraftInterfaceDisableddescription { get; set; }
        public string IsLCDMenuDisableddescription { get; set; }
        public string IsResetButtonDisableddescription { get; set; }

    }
}
