using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class JuniperHardening:EntityBase
    {
        public JuniperHardening()
        {

        }
        public JuniperHardening(long isConsolePortSecured, string isConsolePortSecureddescription, long isRootLoginDisabled, string isRootLoginDisableddescription, long isPasswordRecoveryDisabled, string isPasswordRecoveryDisableddescription, long isAuxiliaryPortDisabled, string isAuxiliaryPortDisableddescription, long isRootLoginAuxDisabled, string isRootLoginAuxDisableddescription, long isDiagnosticPortDisabled, string isDiagnosticPortDisableddescription, long isUsbPortDisabled, string isUsbPortDisableddescription, long isCraftInterfaceDisabled, string isCraftInterfaceDisableddescription, long isLcdMenuDisabled, string isLcdMenuDisableddescription, long isResetButtonDisabled, string isResetButtonDisableddescription, long areUnusedInterfacesDisabled, string areUnusedInterfacesDisableddescription, long isConfigFileEncrypted, string isConfigFileEncrypteddescription)
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


        public long? IsConsolePortSecured { get; set; }
        public string? IsConsolePortSecureddescription { get; set; }
        public long? IsRootLoginDisabled { get; set; }
        public string? IsRootLoginDisableddescription { get; set; }
        public long? IsPasswordRecoveryDisabled { get; set; }
        public string? IsPasswordRecoveryDisableddescription { get; set; }
        public long? IsAuxiliaryPortDisabled { get; set; }
        public string? IsAuxiliaryPortDisableddescription { get; set; }
        public long? IsRootLoginAuxDisabled { get; set; }
        public string? IsRootLoginAuxDisableddescription { get; set; }
        public long? IsDiagnosticPortDisabled { get; set; }
        public string? IsDiagnosticPortDisableddescription { get; set; }
        public long? IsUSBPortDisabled { get; set; }
        public string? IsUSBPortDisableddescription { get; set; }
        public long? IsCraftInterfaceDisabled { get; set; }
        public string? IsCraftInterfaceDisableddescription { get; set; }
        public long? IsLCDMenuDisabled { get; set; }
        public string? IsLCDMenuDisableddescription { get; set; }
        public long? IsResetButtonDisabled { get; set; }
        public string? IsResetButtonDisableddescription { get; set; }
        public long? AreUnusedInterfacesDisabled { get; set; }
        public string? AreUnusedInterfacesDisableddescription { get; set; }
        public long? IsConfigFileEncrypted { get; set; }
        public string? IsConfigFileEncrypteddescription { get; set; }
        public double AverageJuniper { get; private set; }
        public Checklist Checklist { get; set; }

        public void AverageJunipercal(CreateJuniperChecklist command)
        {

            IsConsolePortSecured ??= 0;
            IsRootLoginDisabled ??= 0;
            IsPasswordRecoveryDisabled ??= 0;
            IsAuxiliaryPortDisabled ??= 0;
            IsRootLoginAuxDisabled ??= 0;
            IsDiagnosticPortDisabled ??= 0;
            IsUSBPortDisabled ??= 0;
            IsCraftInterfaceDisabled ??= 0;
            IsLCDMenuDisabled ??= 0;
            IsResetButtonDisabled ??= 0;
            AreUnusedInterfacesDisabled ??= 0;
            IsConfigFileEncrypted ??= 0;

            var Sum = command.IsConsolePortSecured + command.IsRootLoginDisabled + command.IsPasswordRecoveryDisabled +
                      command.IsAuxiliaryPortDisabled + command.IsRootLoginAuxDisabled +
                      command.IsDiagnosticPortDisabled +
                      command.IsUSBPortDisabled + command.IsCraftInterfaceDisabled + command.IsLCDMenuDisabled +
                      command.IsResetButtonDisabled + command.AreUnusedInterfacesDisabled +
                      command.IsConfigFileEncrypted;

            var Avg = ((double)Sum / 12);
            var Average = Math.Round(Avg, 2);
            AverageJuniper = Average;

        }
    }
}
