using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateJuniperChecklist
    {
        public bool IsConsolePortSecured { get; set; }
        public string IsConsolePortSecureddescription { get; set; }
        public bool IsRootLoginDisabled { get; set; }
        public string IsRootLoginDisableddescription { get; set; }
        public bool IsPasswordRecoveryDisabled { get; set; }
        public string IsPasswordRecoveryDisableddescription { get; set; }
        public bool IsAuxiliaryPortDisabled { get; set; }
        public string IsAuxiliaryPortDisableddescription { get; set; }
        public bool IsRootLoginAuxDisabled { get; set; }
        public string IsRootLoginAuxDisableddescription { get; set; }
        public bool IsDiagnosticPortDisabled { get; set; }
        public string IsDiagnosticPortDisableddescription { get; set; }
        public bool IsUSBPortDisabled { get; set; }
        public string IsUSBPortDisableddescription { get; set; }
        public bool IsCraftInterfaceDisabled { get; set; }
        public string IsCraftInterfaceDisableddescription { get; set; }
        public bool IsLCDMenuDisabled { get; set; }
        public string IsLCDMenuDisableddescription { get; set; }
        public bool IsResetButtonDisabled { get; set; }
        public string IsResetButtonDisableddescription { get; set; }
        public bool AreUnusedInterfacesDisabled { get; set; }
        public string AreUnusedInterfacesDisableddescription { get; set; }
        public bool IsConfigFileEncrypted { get; set; }
        public string IsConfigFileEncrypteddescription { get; set; }
        public long ChecklistId { get; set; } 

    }
}
