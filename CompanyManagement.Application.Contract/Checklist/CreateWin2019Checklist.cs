using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Contract.Checklist
{
    public  class CreateWin2019Checklist
    {
        public long  IsPasswordHistoryEnabled { get; set; }
        public string IsPasswordHistoryEnabledDescription { get; set; }

        public long IsMaxPasswordAgeConfigured { get; set; }
        public string IsMaxPasswordAgeConfiguredDescription { get; set; }

        public long IsMinPasswordAgeConfigured { get; set; }
        public string IsMinPasswordAgeConfiguredDescription { get; set; }

        public long IsMinPasswordLengthConfigured { get; set; }
        public string IsMinPasswordLengthConfiguredDescription { get; set; }

        public long IsComplexPasswordRequired { get; set; }
        public string IsComplexPasswordRequiredDescription { get; set; }

        public long IsPlainTextPasswordStorageDisabled { get; set; }
        public string IsPlainTextPasswordStorageDisabledDescription { get; set; }

        public long IsAccountLockoutDurationConfigured { get; set; }
        public string IsAccountLockoutDurationConfiguredDescription { get; set; }

        public long IsFailedLogonAttemptsLimited { get; set; }
        public string IsFailedLogonAttemptsLimitedDescription { get; set; }

        public long IsAdminLockoutConfigured { get; set; }
        public string IsAdminLockoutConfiguredDescription { get; set; }

        public long IsPasswordResetErrorCountConfigured { get; set; }
        public string IsPasswordResetErrorCountConfiguredDescription { get; set; }

        public long IsUserAccountManagementRestricted { get; set; }
        public string IsUserAccountManagementRestrictedDescription { get; set; }

        public long IsRemoteAccessManaged { get; set; }
        public string IsRemoteAccessManagedDescription { get; set; }

        public long IsOSAccountAccessLimited { get; set; }
        public string IsOSAccountAccessLimitedDescription { get; set; }

        public long IsDomainJoinRestricted { get; set; }
        public string IsDomainJoinRestrictedDescription { get; set; }

        public long IsMemoryManagementPermissionGranted { get; set; }
        public string IsMemoryManagementPermissionGrantedDescription { get; set; }

        public long IsLocalConsoleLogonRestricted { get; set; }
        public string IsLocalConsoleLogonRestrictedDescription { get; set; }

        public long IsRemoteLogonGroupManaged { get; set; }
        public string IsRemoteLogonGroupManagedDescription { get; set; }

        public long IsBackupAccessManaged { get; set; }
        public string IsBackupAccessManagedDescription { get; set; }

        public long IsSystemTimeChangeManaged { get; set; }
        public string IsSystemTimeChangeManagedDescription { get; set; }

        public long IsAccessTokenCreationLimited { get; set; }
        public string IsAccessTokenCreationLimitedDescription { get; set; }

        public long IsRemoteLogonRestrictedForGuests { get; set; }
        public string IsRemoteLogonRestrictedForGuestsDescription { get; set; }

        public long IsScheduledTasksPermissionManaged { get; set; }
        public string IsScheduledTasksPermissionManagedDescription { get; set; }

        public long IsLogonAsServicePermissionManaged { get; set; }
        public string IsLogonAsServicePermissionManagedDescription { get; set; }

        public long IsGuestLogonManaged { get; set; }
        public string IsGuestLogonManagedDescription { get; set; }

        public long IsLocalAccountLogonManaged { get; set; }
        public string IsLocalAccountLogonManagedDescription { get; set; }

        public long IsLogonAsServiceSettingsApplied { get; set; }
        public string IsLogonAsServiceSettingsAppliedDescription { get; set; }

        public long IsRemoteShutdownPermissionManaged { get; set; }
        public string IsRemoteShutdownPermissionManagedDescription { get; set; }

        public long IsAdministratorUsernameChanged { get; set; }
        public string? IsAdministratorUsernameChangedDescription { get; set; }

        public long IsCachedUsernameCountManaged { get; set; }
        public string IsCachedUsernameCountManagedDescription { get; set; }

        public long IsPasswordExpirationWarningManaged { get; set; }
        public string IsPasswordExpirationWarningManagedDescription { get; set; }

        public long IsAnonymousSIDRequestManaged { get; set; }
        public string IsAnonymousSIDRequestManagedDescription { get; set; }

        public long IsNTFSMediaAccessManaged { get; set; }
        public string IsNTFSMediaAccessManagedDescription { get; set; }

        public long IsSharedPrinterDriverInstallationManaged { get; set; }
        public string IsSharedPrinterDriverInstallationManagedDescription { get; set; }

        public long IsPrinterSpoolerServiceManaged { get; set; }
        public string IsPrinterSpoolerServiceManagedDescription { get; set; }

        public long IsOnlineTipManaged { get; set; }
        public string IsOnlineTipManagedDescription { get; set; }

        public long IsKeepAliveTimeManaged { get; set; }
        public string IsKeepAliveTimeManagedDescription { get; set; }

        public long IsIRDPOptionDisabled { get; set; }
        public string IsIRDPOptionDisabledDescription { get; set; }

        public long IsDataRetransmissionManaged { get; set; }
        public string IsDataRetransmissionManagedDescription { get; set; }

        public long ChecklistId { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند

    }
}
