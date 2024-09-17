using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class Win2019:EntityBase
    {
        public Win2019(bool? isPasswordHistoryEnabled, string? isPasswordHistoryEnabledDescription, bool? isMaxPasswordAgeConfigured, string? isMaxPasswordAgeConfiguredDescription, bool? isMinPasswordAgeConfigured, string? isMinPasswordAgeConfiguredDescription, bool? isMinPasswordLengthConfigured, string? isMinPasswordLengthConfiguredDescription, bool? isComplexPasswordRequired, string? isComplexPasswordRequiredDescription, bool? isPlainTextPasswordStorageDisabled, string? isPlainTextPasswordStorageDisabledDescription, bool? isAccountLockoutDurationConfigured, string? isAccountLockoutDurationConfiguredDescription, bool? isFailedLogonAttemptsLimited, string? isFailedLogonAttemptsLimitedDescription, bool? isAdminLockoutConfigured, string? isAdminLockoutConfiguredDescription, bool? isPasswordResetErrorCountConfigured, string? isPasswordResetErrorCountConfiguredDescription, bool? isUserAccountManagementRestricted, string? isUserAccountManagementRestrictedDescription, bool? isRemoteAccessManaged, string? isRemoteAccessManagedDescription, bool? isOsAccountAccessLimited, string? isOsAccountAccessLimitedDescription, bool? isDomainJoinRestricted, string? isDomainJoinRestrictedDescription, bool? isMemoryManagementPermissionGranted, string? isMemoryManagementPermissionGrantedDescription, bool? isLocalConsoleLogonRestricted, string? isLocalConsoleLogonRestrictedDescription, bool? isRemoteLogonGroupManaged, string? isRemoteLogonGroupManagedDescription, bool? isBackupAccessManaged, string? isBackupAccessManagedDescription, bool? isSystemTimeChangeManaged, string? isSystemTimeChangeManagedDescription, bool? isAccessTokenCreationLimited, string? isAccessTokenCreationLimitedDescription, bool? isRemoteLogonRestrictedForGuests, string? isRemoteLogonRestrictedForGuestsDescription, bool? isScheduledTasksPermissionManaged, string? isScheduledTasksPermissionManagedDescription, bool? isLogonAsServicePermissionManaged, string? isLogonAsServicePermissionManagedDescription, bool? isGuestLogonManaged, string? isGuestLogonManagedDescription, bool? isLocalAccountLogonManaged, string? isLocalAccountLogonManagedDescription, bool? isLogonAsServiceSettingsApplied, string? isLogonAsServiceSettingsAppliedDescription, bool? isRemoteShutdownPermissionManaged, string? isRemoteShutdownPermissionManagedDescription, bool? isAdministratorUsernameChanged, string? isAdministratorUsernameChangedDescription, bool? isCachedUsernameCountManaged, string? isCachedUsernameCountManagedDescription, bool? isPasswordExpirationWarningManaged, string? isPasswordExpirationWarningManagedDescription, bool? isAnonymousSidRequestManaged, string? isAnonymousSidRequestManagedDescription, bool? isNtfsMediaAccessManaged, string? isNtfsMediaAccessManagedDescription, bool? isSharedPrinterDriverInstallationManaged, string? isSharedPrinterDriverInstallationManagedDescription, bool? isPrinterSpoolerServiceManaged, string? isPrinterSpoolerServiceManagedDescription, bool? isOnlineTipManaged, string? isOnlineTipManagedDescription, bool? isKeepAliveTimeManaged, string? isKeepAliveTimeManagedDescription, bool? isIrdpOptionDisabled, string? isIrdpOptionDisabledDescription, bool? isDataRetransmissionManaged, string? isDataRetransmissionManagedDescription)
        {
            IsPasswordHistoryEnabled = isPasswordHistoryEnabled;
            IsPasswordHistoryEnabledDescription = isPasswordHistoryEnabledDescription;
            IsMaxPasswordAgeConfigured = isMaxPasswordAgeConfigured;
            IsMaxPasswordAgeConfiguredDescription = isMaxPasswordAgeConfiguredDescription;
            IsMinPasswordAgeConfigured = isMinPasswordAgeConfigured;
            IsMinPasswordAgeConfiguredDescription = isMinPasswordAgeConfiguredDescription;
            IsMinPasswordLengthConfigured = isMinPasswordLengthConfigured;
            IsMinPasswordLengthConfiguredDescription = isMinPasswordLengthConfiguredDescription;
            IsComplexPasswordRequired = isComplexPasswordRequired;
            IsComplexPasswordRequiredDescription = isComplexPasswordRequiredDescription;
            IsPlainTextPasswordStorageDisabled = isPlainTextPasswordStorageDisabled;
            IsPlainTextPasswordStorageDisabledDescription = isPlainTextPasswordStorageDisabledDescription;
            IsAccountLockoutDurationConfigured = isAccountLockoutDurationConfigured;
            IsAccountLockoutDurationConfiguredDescription = isAccountLockoutDurationConfiguredDescription;
            IsFailedLogonAttemptsLimited = isFailedLogonAttemptsLimited;
            IsFailedLogonAttemptsLimitedDescription = isFailedLogonAttemptsLimitedDescription;
            IsAdminLockoutConfigured = isAdminLockoutConfigured;
            IsAdminLockoutConfiguredDescription = isAdminLockoutConfiguredDescription;
            IsPasswordResetErrorCountConfigured = isPasswordResetErrorCountConfigured;
            IsPasswordResetErrorCountConfiguredDescription = isPasswordResetErrorCountConfiguredDescription;
            IsUserAccountManagementRestricted = isUserAccountManagementRestricted;
            IsUserAccountManagementRestrictedDescription = isUserAccountManagementRestrictedDescription;
            IsRemoteAccessManaged = isRemoteAccessManaged;
            IsRemoteAccessManagedDescription = isRemoteAccessManagedDescription;
            IsOSAccountAccessLimited = isOsAccountAccessLimited;
            IsOSAccountAccessLimitedDescription = isOsAccountAccessLimitedDescription;
            IsDomainJoinRestricted = isDomainJoinRestricted;
            IsDomainJoinRestrictedDescription = isDomainJoinRestrictedDescription;
            IsMemoryManagementPermissionGranted = isMemoryManagementPermissionGranted;
            IsMemoryManagementPermissionGrantedDescription = isMemoryManagementPermissionGrantedDescription;
            IsLocalConsoleLogonRestricted = isLocalConsoleLogonRestricted;
            IsLocalConsoleLogonRestrictedDescription = isLocalConsoleLogonRestrictedDescription;
            IsRemoteLogonGroupManaged = isRemoteLogonGroupManaged;
            IsRemoteLogonGroupManagedDescription = isRemoteLogonGroupManagedDescription;
            IsBackupAccessManaged = isBackupAccessManaged;
            IsBackupAccessManagedDescription = isBackupAccessManagedDescription;
            IsSystemTimeChangeManaged = isSystemTimeChangeManaged;
            IsSystemTimeChangeManagedDescription = isSystemTimeChangeManagedDescription;
            IsAccessTokenCreationLimited = isAccessTokenCreationLimited;
            IsAccessTokenCreationLimitedDescription = isAccessTokenCreationLimitedDescription;
            IsRemoteLogonRestrictedForGuests = isRemoteLogonRestrictedForGuests;
            IsRemoteLogonRestrictedForGuestsDescription = isRemoteLogonRestrictedForGuestsDescription;
            IsScheduledTasksPermissionManaged = isScheduledTasksPermissionManaged;
            IsScheduledTasksPermissionManagedDescription = isScheduledTasksPermissionManagedDescription;
            IsLogonAsServicePermissionManaged = isLogonAsServicePermissionManaged;
            IsLogonAsServicePermissionManagedDescription = isLogonAsServicePermissionManagedDescription;
            IsGuestLogonManaged = isGuestLogonManaged;
            IsGuestLogonManagedDescription = isGuestLogonManagedDescription;
            IsLocalAccountLogonManaged = isLocalAccountLogonManaged;
            IsLocalAccountLogonManagedDescription = isLocalAccountLogonManagedDescription;
            IsLogonAsServiceSettingsApplied = isLogonAsServiceSettingsApplied;
            IsLogonAsServiceSettingsAppliedDescription = isLogonAsServiceSettingsAppliedDescription;
            IsRemoteShutdownPermissionManaged = isRemoteShutdownPermissionManaged;
            IsRemoteShutdownPermissionManagedDescription = isRemoteShutdownPermissionManagedDescription;
            IsAdministratorUsernameChanged = isAdministratorUsernameChanged;
            IsAdministratorUsernameChangedDescription = isAdministratorUsernameChangedDescription;
            IsCachedUsernameCountManaged = isCachedUsernameCountManaged;
            IsCachedUsernameCountManagedDescription = isCachedUsernameCountManagedDescription;
            IsPasswordExpirationWarningManaged = isPasswordExpirationWarningManaged;
            IsPasswordExpirationWarningManagedDescription = isPasswordExpirationWarningManagedDescription;
            IsAnonymousSIDRequestManaged = isAnonymousSidRequestManaged;
            IsAnonymousSIDRequestManagedDescription = isAnonymousSidRequestManagedDescription;
            IsNTFSMediaAccessManaged = isNtfsMediaAccessManaged;
            IsNTFSMediaAccessManagedDescription = isNtfsMediaAccessManagedDescription;
            IsSharedPrinterDriverInstallationManaged = isSharedPrinterDriverInstallationManaged;
            IsSharedPrinterDriverInstallationManagedDescription = isSharedPrinterDriverInstallationManagedDescription;
            IsPrinterSpoolerServiceManaged = isPrinterSpoolerServiceManaged;
            IsPrinterSpoolerServiceManagedDescription = isPrinterSpoolerServiceManagedDescription;
            IsOnlineTipManaged = isOnlineTipManaged;
            IsOnlineTipManagedDescription = isOnlineTipManagedDescription;
            IsKeepAliveTimeManaged = isKeepAliveTimeManaged;
            IsKeepAliveTimeManagedDescription = isKeepAliveTimeManagedDescription;
            IsIRDPOptionDisabled = isIrdpOptionDisabled;
            IsIRDPOptionDisabledDescription = isIrdpOptionDisabledDescription;
            IsDataRetransmissionManaged = isDataRetransmissionManaged;
            IsDataRetransmissionManagedDescription = isDataRetransmissionManagedDescription;
        }

        public Win2019()
        {

        }

        public bool? IsPasswordHistoryEnabled { get; set; }
        public string? IsPasswordHistoryEnabledDescription { get; set; }

        public bool? IsMaxPasswordAgeConfigured { get; set; }
        public string? IsMaxPasswordAgeConfiguredDescription { get; set; }

        public bool? IsMinPasswordAgeConfigured { get; set; }
        public string? IsMinPasswordAgeConfiguredDescription { get; set; }

        public bool? IsMinPasswordLengthConfigured { get; set; }
        public string? IsMinPasswordLengthConfiguredDescription { get; set; }

        public bool? IsComplexPasswordRequired { get; set; }
        public string? IsComplexPasswordRequiredDescription { get; set; }

        public bool? IsPlainTextPasswordStorageDisabled { get; set; }
        public string? IsPlainTextPasswordStorageDisabledDescription { get; set; }

        public bool? IsAccountLockoutDurationConfigured { get; set; }
        public string? IsAccountLockoutDurationConfiguredDescription { get; set; }

        public bool? IsFailedLogonAttemptsLimited { get; set; }
        public string? IsFailedLogonAttemptsLimitedDescription { get; set; }

        public bool? IsAdminLockoutConfigured { get; set; }
        public string? IsAdminLockoutConfiguredDescription { get; set; }

        public bool? IsPasswordResetErrorCountConfigured { get; set; }
        public string? IsPasswordResetErrorCountConfiguredDescription { get; set; }

        public bool? IsUserAccountManagementRestricted { get; set; }
        public string? IsUserAccountManagementRestrictedDescription { get; set; }

        public bool? IsRemoteAccessManaged { get; set; }
        public string? IsRemoteAccessManagedDescription { get; set; }

        public bool? IsOSAccountAccessLimited { get; set; }
        public string? IsOSAccountAccessLimitedDescription { get; set; }

        public bool? IsDomainJoinRestricted { get; set; }
        public string? IsDomainJoinRestrictedDescription { get; set; }

        public bool? IsMemoryManagementPermissionGranted { get; set; }
        public string? IsMemoryManagementPermissionGrantedDescription { get; set; }

        public bool? IsLocalConsoleLogonRestricted { get; set; }
        public string? IsLocalConsoleLogonRestrictedDescription { get; set; }

        public bool? IsRemoteLogonGroupManaged { get; set; }
        public string? IsRemoteLogonGroupManagedDescription { get; set; }

        public bool? IsBackupAccessManaged { get; set; }
        public string? IsBackupAccessManagedDescription { get; set; }

        public bool? IsSystemTimeChangeManaged { get; set; }
        public string? IsSystemTimeChangeManagedDescription { get; set; }

        public bool? IsAccessTokenCreationLimited { get; set; }
        public string? IsAccessTokenCreationLimitedDescription { get; set; }

        public bool? IsRemoteLogonRestrictedForGuests { get; set; }
        public string? IsRemoteLogonRestrictedForGuestsDescription { get; set; }

        public bool? IsScheduledTasksPermissionManaged { get; set; }
        public string? IsScheduledTasksPermissionManagedDescription { get; set; }

        public bool? IsLogonAsServicePermissionManaged { get; set; }
        public string? IsLogonAsServicePermissionManagedDescription { get; set; }

        public bool? IsGuestLogonManaged { get; set; }
        public string? IsGuestLogonManagedDescription { get; set; }

        public bool? IsLocalAccountLogonManaged { get; set; }
        public string? IsLocalAccountLogonManagedDescription { get; set; }

        public bool? IsLogonAsServiceSettingsApplied { get; set; }
        public string? IsLogonAsServiceSettingsAppliedDescription { get; set; }

        public bool? IsRemoteShutdownPermissionManaged { get; set; }
        public string? IsRemoteShutdownPermissionManagedDescription { get; set; }

        public bool? IsAdministratorUsernameChanged { get; set; }
        public string? IsAdministratorUsernameChangedDescription { get; set; }

        public bool? IsCachedUsernameCountManaged { get; set; }
        public string? IsCachedUsernameCountManagedDescription { get; set; }

        public bool? IsPasswordExpirationWarningManaged { get; set; }
        public string? IsPasswordExpirationWarningManagedDescription { get; set; }

        public bool? IsAnonymousSIDRequestManaged { get; set; }
        public string? IsAnonymousSIDRequestManagedDescription { get; set; }

        public bool? IsNTFSMediaAccessManaged { get; set; }
        public string? IsNTFSMediaAccessManagedDescription { get; set; }

        public bool? IsSharedPrinterDriverInstallationManaged { get; set; }
        public string? IsSharedPrinterDriverInstallationManagedDescription { get; set; }

        public bool? IsPrinterSpoolerServiceManaged { get; set; }
        public string? IsPrinterSpoolerServiceManagedDescription { get; set; }

        public bool? IsOnlineTipManaged { get; set; }
        public string? IsOnlineTipManagedDescription { get; set; }

        public bool? IsKeepAliveTimeManaged { get; set; }
        public string? IsKeepAliveTimeManagedDescription { get; set; }

        public bool? IsIRDPOptionDisabled { get; set; }
        public string? IsIRDPOptionDisabledDescription { get; set; }

        public bool? IsDataRetransmissionManaged { get; set; }
        public string? IsDataRetransmissionManagedDescription { get; set; }

        public Checklist Checklist { get; set; }
    }

}
