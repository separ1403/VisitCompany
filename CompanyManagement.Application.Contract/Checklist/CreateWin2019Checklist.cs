using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateWin2019Checklist
    {
        public bool IsPasswordHistoryEnabled { get; set; }
        public string IsPasswordHistoryEnabledDescription { get; set; }

        public bool IsMaxPasswordAgeConfigured { get; set; }
        public string IsMaxPasswordAgeConfiguredDescription { get; set; }

        public bool IsMinPasswordAgeConfigured { get; set; }
        public string IsMinPasswordAgeConfiguredDescription { get; set; }

        public bool IsMinPasswordLengthConfigured { get; set; }
        public string IsMinPasswordLengthConfiguredDescription { get; set; }

        public bool IsComplexPasswordRequired { get; set; }
        public string IsComplexPasswordRequiredDescription { get; set; }

        public bool IsPlainTextPasswordStorageDisabled { get; set; }
        public string IsPlainTextPasswordStorageDisabledDescription { get; set; }

        public bool IsAccountLockoutDurationConfigured { get; set; }
        public string IsAccountLockoutDurationConfiguredDescription { get; set; }

        public bool IsFailedLogonAttemptsLimited { get; set; }
        public string IsFailedLogonAttemptsLimitedDescription { get; set; }

        public bool IsAdminLockoutConfigured { get; set; }
        public string IsAdminLockoutConfiguredDescription { get; set; }

        public bool IsPasswordResetErrorCountConfigured { get; set; }
        public string IsPasswordResetErrorCountConfiguredDescription { get; set; }

        public bool IsUserAccountManagementRestricted { get; set; }
        public string IsUserAccountManagementRestrictedDescription { get; set; }

        public bool IsRemoteAccessManaged { get; set; }
        public string IsRemoteAccessManagedDescription { get; set; }

        public bool IsOSAccountAccessLimited { get; set; }
        public string IsOSAccountAccessLimitedDescription { get; set; }

        public bool IsDomainJoinRestricted { get; set; }
        public string IsDomainJoinRestrictedDescription { get; set; }

        public bool IsMemoryManagementPermissionGranted { get; set; }
        public string IsMemoryManagementPermissionGrantedDescription { get; set; }

        public bool IsLocalConsoleLogonRestricted { get; set; }
        public string IsLocalConsoleLogonRestrictedDescription { get; set; }

        public bool IsRemoteLogonGroupManaged { get; set; }
        public string IsRemoteLogonGroupManagedDescription { get; set; }

        public bool IsBackupAccessManaged { get; set; }
        public string IsBackupAccessManagedDescription { get; set; }

        public bool IsSystemTimeChangeManaged { get; set; }
        public string IsSystemTimeChangeManagedDescription { get; set; }

        public bool IsAccessTokenCreationLimited { get; set; }
        public string IsAccessTokenCreationLimitedDescription { get; set; }

        public bool IsRemoteLogonRestrictedForGuests { get; set; }
        public string IsRemoteLogonRestrictedForGuestsDescription { get; set; }

        public bool IsScheduledTasksPermissionManaged { get; set; }
        public string IsScheduledTasksPermissionManagedDescription { get; set; }

        public bool IsLogonAsServicePermissionManaged { get; set; }
        public string IsLogonAsServicePermissionManagedDescription { get; set; }

        public bool IsGuestLogonManaged { get; set; }
        public string IsGuestLogonManagedDescription { get; set; }

        public bool IsLocalAccountLogonManaged { get; set; }
        public string IsLocalAccountLogonManagedDescription { get; set; }

        public bool IsLogonAsServiceSettingsApplied { get; set; }
        public string IsLogonAsServiceSettingsAppliedDescription { get; set; }

        public bool IsRemoteShutdownPermissionManaged { get; set; }
        public string IsRemoteShutdownPermissionManagedDescription { get; set; }

        public bool IsAdministratorUsernameChanged { get; set; }
        public string? IsAdministratorUsernameChangedDescription { get; set; }

        public bool IsCachedUsernameCountManaged { get; set; }
        public string IsCachedUsernameCountManagedDescription { get; set; }

        public bool IsPasswordExpirationWarningManaged { get; set; }
        public string IsPasswordExpirationWarningManagedDescription { get; set; }

        public bool IsAnonymousSIDRequestManaged { get; set; }
        public string IsAnonymousSIDRequestManagedDescription { get; set; }

        public bool IsNTFSMediaAccessManaged { get; set; }
        public string IsNTFSMediaAccessManagedDescription { get; set; }

        public bool IsSharedPrinterDriverInstallationManaged { get; set; }
        public string IsSharedPrinterDriverInstallationManagedDescription { get; set; }

        public bool IsPrinterSpoolerServiceManaged { get; set; }
        public string IsPrinterSpoolerServiceManagedDescription { get; set; }

        public bool IsOnlineTipManaged { get; set; }
        public string IsOnlineTipManagedDescription { get; set; }

        public bool IsKeepAliveTimeManaged { get; set; }
        public string IsKeepAliveTimeManagedDescription { get; set; }

        public bool IsIRDPOptionDisabled { get; set; }
        public string IsIRDPOptionDisabledDescription { get; set; }

        public bool IsDataRetransmissionManaged { get; set; }
        public string IsDataRetransmissionManagedDescription { get; set; }

        public long ChecklistId { get; set; }
    }
}
