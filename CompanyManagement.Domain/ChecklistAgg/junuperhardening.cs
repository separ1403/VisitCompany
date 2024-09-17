using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class JuniperHardening:EntityBase
    {
        public JuniperHardening()
        {

        }
        public JuniperHardening(bool isConsolePortSecured, string isConsolePortSecureddescription, bool isRootLoginDisabled, string isRootLoginDisableddescription, bool isPasswordRecoveryDisabled, string isPasswordRecoveryDisableddescription, bool isAuxiliaryPortDisabled, string isAuxiliaryPortDisableddescription, bool isRootLoginAuxDisabled, string isRootLoginAuxDisableddescription, bool isDiagnosticPortDisabled, string isDiagnosticPortDisableddescription, bool isUsbPortDisabled, string isUsbPortDisableddescription, bool isCraftInterfaceDisabled, string isCraftInterfaceDisableddescription, bool isLcdMenuDisabled, string isLcdMenuDisableddescription, bool isResetButtonDisabled, string isResetButtonDisableddescription, bool areUnusedInterfacesDisabled, string areUnusedInterfacesDisableddescription, bool isConfigFileEncrypted, string isConfigFileEncrypteddescription)
        {
            IsConsolePortSecured = isConsolePortSecured;
            IsConsolePortSecureddescription = isConsolePortSecureddescription;
            IsRootLoginDisabled = isRootLoginDisabled;
            IsRootLoginDisableddescription = isRootLoginDisableddescription;
            IsPasswordRecoveryDisabled = isPasswordRecoveryDisabled;
            IsPasswordRecoveryDisableddescription = isPasswordRecoveryDisableddescription;
            IsAuxiliaryPortDisabled = isAuxiliaryPortDisabled;
            IsAuxiliaryPortDisableddescription = isAuxiliaryPortDisableddescription;
            IsRootLoginAuxDisabled = isRootLoginAuxDisabled;
            IsRootLoginAuxDisableddescription = isRootLoginAuxDisableddescription;
            IsDiagnosticPortDisabled = isDiagnosticPortDisabled;
            IsDiagnosticPortDisableddescription = isDiagnosticPortDisableddescription;
            IsUSBPortDisabled = isUsbPortDisabled;
            IsUSBPortDisableddescription = isUsbPortDisableddescription;
            IsCraftInterfaceDisabled = isCraftInterfaceDisabled;
            IsCraftInterfaceDisableddescription = isCraftInterfaceDisableddescription;
            IsLCDMenuDisabled = isLcdMenuDisabled;
            IsLCDMenuDisableddescription = isLcdMenuDisableddescription;
            IsResetButtonDisabled = isResetButtonDisabled;
            IsResetButtonDisableddescription = isResetButtonDisableddescription;
            AreUnusedInterfacesDisabled = areUnusedInterfacesDisabled;
            AreUnusedInterfacesDisableddescription = areUnusedInterfacesDisableddescription;
            IsConfigFileEncrypted = isConfigFileEncrypted;
            IsConfigFileEncrypteddescription = isConfigFileEncrypteddescription;
        }


        public bool? IsConsolePortSecured { get; set; }
        public string? IsConsolePortSecureddescription { get; set; }
        public bool? IsRootLoginDisabled { get; set; }
        public string? IsRootLoginDisableddescription { get; set; }
        public bool? IsPasswordRecoveryDisabled { get; set; }
        public string? IsPasswordRecoveryDisableddescription { get; set; }
        public bool? IsAuxiliaryPortDisabled { get; set; }
        public string? IsAuxiliaryPortDisableddescription { get; set; }
        public bool? IsRootLoginAuxDisabled { get; set; }
        public string? IsRootLoginAuxDisableddescription { get; set; }
        public bool? IsDiagnosticPortDisabled { get; set; }
        public string? IsDiagnosticPortDisableddescription { get; set; }
        public bool? IsUSBPortDisabled { get; set; }
        public string? IsUSBPortDisableddescription { get; set; }
        public bool? IsCraftInterfaceDisabled { get; set; }
        public string? IsCraftInterfaceDisableddescription { get; set; }
        public bool? IsLCDMenuDisabled { get; set; }
        public string? IsLCDMenuDisableddescription { get; set; }
        public bool? IsResetButtonDisabled { get; set; }
        public string? IsResetButtonDisableddescription { get; set; }
        public bool? AreUnusedInterfacesDisabled { get; set; }
        public string? AreUnusedInterfacesDisableddescription { get; set; }
        public bool? IsConfigFileEncrypted { get; set; }
        public string? IsConfigFileEncrypteddescription { get; set; }
        public Checklist Checklist { get; set; }
    }
}
