using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateJuniperChecklist
    {
        public long IsConsolePortSecured { get; set; }
        public string IsConsolePortSecureddescription { get; set; }
        public long IsRootLoginDisabled { get; set; }
        public string IsRootLoginDisableddescription { get; set; }
        public long IsPasswordRecoveryDisabled { get; set; }
        public string IsPasswordRecoveryDisableddescription { get; set; }
        public long IsAuxiliaryPortDisabled { get; set; }
        public string IsAuxiliaryPortDisableddescription { get; set; }
        public long IsRootLoginAuxDisabled { get; set; }
        public string IsRootLoginAuxDisableddescription { get; set; }
        public long IsDiagnosticPortDisabled { get; set; }
        public string IsDiagnosticPortDisableddescription { get; set; }
        public long IsUSBPortDisabled { get; set; }
        public string IsUSBPortDisableddescription { get; set; }
        public long IsCraftInterfaceDisabled { get; set; }
        public string IsCraftInterfaceDisableddescription { get; set; }
        public long IsLCDMenuDisabled { get; set; }
        public string IsLCDMenuDisableddescription { get; set; }
        public long IsResetButtonDisabled { get; set; }
        public string IsResetButtonDisableddescription { get; set; }
        public long AreUnusedInterfacesDisabled { get; set; }
        public string AreUnusedInterfacesDisableddescription { get; set; }
        public long IsConfigFileEncrypted { get; set; }
        public string IsConfigFileEncrypteddescription { get; set; }
        public long ChecklistId { get; set; } 

    }
}
