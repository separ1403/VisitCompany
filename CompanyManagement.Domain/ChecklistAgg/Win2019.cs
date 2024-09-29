using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Application.Contract.Checklist;
using Framework.Domain;

namespace CompanyManagement.Domain.ChecklistAgg
{
    public class Win2019:EntityBase
    {
        public Win2019(long? isPasswordHistoryEnabled, string? isPasswordHistoryEnabledDescription, long? isMaxPasswordAgeConfigured, string? isMaxPasswordAgeConfiguredDescription, long? isMinPasswordAgeConfigured, string? isMinPasswordAgeConfiguredDescription, long? isMinPasswordLengthConfigured, string? isMinPasswordLengthConfiguredDescription, long? isComplexPasswordRequired, string? isComplexPasswordRequiredDescription, long? isPlainTextPasswordStorageDisabled, string? isPlainTextPasswordStorageDisabledDescription, long? isAccountLockoutDurationConfigured, string? isAccountLockoutDurationConfiguredDescription, long? isFailedLogonAttemptsLimited, string? isFailedLogonAttemptsLimitedDescription, long? isAdminLockoutConfigured, string? isAdminLockoutConfiguredDescription, long? isPasswordResetErrorCountConfigured, string? isPasswordResetErrorCountConfiguredDescription, long? isUserAccountManagementRestricted, string? isUserAccountManagementRestrictedDescription, long? isRemoteAccessManaged, string? isRemoteAccessManagedDescription, long? isOsAccountAccessLimited, string? isOsAccountAccessLimitedDescription, long? isDomainJoinRestricted, string? isDomainJoinRestrictedDescription, long? isMemoryManagementPermissionGranted, string? isMemoryManagementPermissionGrantedDescription, long? isLocalConsoleLogonRestricted, string? isLocalConsoleLogonRestrictedDescription, long? isRemoteLogonGroupManaged, string? isRemoteLogonGroupManagedDescription, long? isBackupAccessManaged, string? isBackupAccessManagedDescription, long? isSystemTimeChangeManaged, string? isSystemTimeChangeManagedDescription, long? isAccessTokenCreationLimited, string? isAccessTokenCreationLimitedDescription, long? isRemoteLogonRestrictedForGuests, string? isRemoteLogonRestrictedForGuestsDescription, long? isScheduledTasksPermissionManaged, string? isScheduledTasksPermissionManagedDescription, long? isLogonAsServicePermissionManaged, string? isLogonAsServicePermissionManagedDescription, long? isGuestLogonManaged, string? isGuestLogonManagedDescription, long? isLocalAccountLogonManaged, string? isLocalAccountLogonManagedDescription, long? isLogonAsServiceSettingsApplied, string? isLogonAsServiceSettingsAppliedDescription, long? isRemoteShutdownPermissionManaged, string? isRemoteShutdownPermissionManagedDescription, long? isAdministratorUsernameChanged, string? isAdministratorUsernameChangedDescription, long? isCachedUsernameCountManaged, string? isCachedUsernameCountManagedDescription, long? isPasswordExpirationWarningManaged, string? isPasswordExpirationWarningManagedDescription, long? isAnonymousSidRequestManaged, string? isAnonymousSidRequestManagedDescription, long? isNtfsMediaAccessManaged, string? isNtfsMediaAccessManagedDescription, long? isSharedPrinterDriverInstallationManaged, string? isSharedPrinterDriverInstallationManagedDescription, long? isPrinterSpoolerServiceManaged, string? isPrinterSpoolerServiceManagedDescription, long? isOnlineTipManaged, string? isOnlineTipManagedDescription, long? isKeepAliveTimeManaged, string? isKeepAliveTimeManagedDescription, long? isIrdpOptionDisabled, string? isIrdpOptionDisabledDescription, long? isDataRetransmissionManaged, string? isDataRetransmissionManagedDescription, string finallDescription)
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
            IsCompleted = true;
            FinallDescription = finallDescription;
        }

        public Win2019()
        {

        }

        public long? IsPasswordHistoryEnabled { get; set; }
        public string? IsPasswordHistoryEnabledDescription { get; set; }

        public long? IsMaxPasswordAgeConfigured { get; set; }
        public string? IsMaxPasswordAgeConfiguredDescription { get; set; }

        public long? IsMinPasswordAgeConfigured { get; set; }
        public string? IsMinPasswordAgeConfiguredDescription { get; set; }

        public long? IsMinPasswordLengthConfigured { get; set; }
        public string? IsMinPasswordLengthConfiguredDescription { get; set; }

        public long? IsComplexPasswordRequired { get; set; }
        public string? IsComplexPasswordRequiredDescription { get; set; }

        public long? IsPlainTextPasswordStorageDisabled { get; set; }
        public string? IsPlainTextPasswordStorageDisabledDescription { get; set; }

        public long? IsAccountLockoutDurationConfigured { get; set; }
        public string? IsAccountLockoutDurationConfiguredDescription { get; set; }

        public long? IsFailedLogonAttemptsLimited { get; set; }
        public string? IsFailedLogonAttemptsLimitedDescription { get; set; }

        public long? IsAdminLockoutConfigured { get; set; }
        public string? IsAdminLockoutConfiguredDescription { get; set; }

        public long? IsPasswordResetErrorCountConfigured { get; set; }
        public string? IsPasswordResetErrorCountConfiguredDescription { get; set; }

        public long? IsUserAccountManagementRestricted { get; set; }
        public string? IsUserAccountManagementRestrictedDescription { get; set; }

        public long? IsRemoteAccessManaged { get; set; }
        public string? IsRemoteAccessManagedDescription { get; set; }

        public long? IsOSAccountAccessLimited { get; set; }
        public string? IsOSAccountAccessLimitedDescription { get; set; }

        public long? IsDomainJoinRestricted { get; set; }
        public string? IsDomainJoinRestrictedDescription { get; set; }

        public long? IsMemoryManagementPermissionGranted { get; set; }
        public string? IsMemoryManagementPermissionGrantedDescription { get; set; }

        public long? IsLocalConsoleLogonRestricted { get; set; }
        public string? IsLocalConsoleLogonRestrictedDescription { get; set; }

        public long? IsRemoteLogonGroupManaged { get; set; }
        public string? IsRemoteLogonGroupManagedDescription { get; set; }

        public long? IsBackupAccessManaged { get; set; }
        public string? IsBackupAccessManagedDescription { get; set; }

        public long? IsSystemTimeChangeManaged { get; set; }
        public string? IsSystemTimeChangeManagedDescription { get; set; }

        public long? IsAccessTokenCreationLimited { get; set; }
        public string? IsAccessTokenCreationLimitedDescription { get; set; }

        public long? IsRemoteLogonRestrictedForGuests { get; set; }
        public string? IsRemoteLogonRestrictedForGuestsDescription { get; set; }

        public long? IsScheduledTasksPermissionManaged { get; set; }
        public string? IsScheduledTasksPermissionManagedDescription { get; set; }

        public long? IsLogonAsServicePermissionManaged { get; set; }
        public string? IsLogonAsServicePermissionManagedDescription { get; set; }

        public long? IsGuestLogonManaged { get; set; }
        public string? IsGuestLogonManagedDescription { get; set; }

        public long? IsLocalAccountLogonManaged { get; set; }
        public string? IsLocalAccountLogonManagedDescription { get; set; }

        public long? IsLogonAsServiceSettingsApplied { get; set; }
        public string? IsLogonAsServiceSettingsAppliedDescription { get; set; }

        public long? IsRemoteShutdownPermissionManaged { get; set; }
        public string? IsRemoteShutdownPermissionManagedDescription { get; set; }

        public long? IsAdministratorUsernameChanged { get; set; }
        public string? IsAdministratorUsernameChangedDescription { get; set; }

        public long? IsCachedUsernameCountManaged { get; set; }
        public string? IsCachedUsernameCountManagedDescription { get; set; }

        public long? IsPasswordExpirationWarningManaged { get; set; }
        public string? IsPasswordExpirationWarningManagedDescription { get; set; }

        public long? IsAnonymousSIDRequestManaged { get; set; }
        public string? IsAnonymousSIDRequestManagedDescription { get; set; }

        public long? IsNTFSMediaAccessManaged { get; set; }
        public string? IsNTFSMediaAccessManagedDescription { get; set; }

        public long? IsSharedPrinterDriverInstallationManaged { get; set; }
        public string? IsSharedPrinterDriverInstallationManagedDescription { get; set; }

        public long? IsPrinterSpoolerServiceManaged { get; set; }
        public string? IsPrinterSpoolerServiceManagedDescription { get; set; }

        public long? IsOnlineTipManaged { get; set; }
        public string? IsOnlineTipManagedDescription { get; set; }

        public long? IsKeepAliveTimeManaged { get; set; }
        public string? IsKeepAliveTimeManagedDescription { get; set; }

        public long? IsIRDPOptionDisabled { get; set; }
        public string? IsIRDPOptionDisabledDescription { get; set; }

        public long? IsDataRetransmissionManaged { get; set; }
        public string? IsDataRetransmissionManagedDescription { get; set; }

        public double AverageWin2019 { get; private set; }

        public Checklist Checklist { get; set; }
        public bool IsCompleted { get; set; } // فیلدی که وضعیت ارزیابی را ذخیره می‌کند
        public string? FinallDescription { get; private set; }




        public void AverageWin2019cal(CreateWin2019Checklist command)
        {
            IsPasswordHistoryEnabled ??= 0;
            IsMaxPasswordAgeConfigured ??= 0;
            IsMinPasswordAgeConfigured ??= 0;
            IsMinPasswordLengthConfigured ??= 0;
            IsComplexPasswordRequired ??= 0;
            IsPlainTextPasswordStorageDisabled ??= 0;
            IsAccountLockoutDurationConfigured ??= 0;
            IsFailedLogonAttemptsLimited ??= 0;
            IsAdminLockoutConfigured ??= 0;
            IsPasswordResetErrorCountConfigured ??= 0;
            IsUserAccountManagementRestricted ??= 0;
            IsRemoteAccessManaged ??= 0;
            IsOSAccountAccessLimited ??= 0;
            IsDomainJoinRestricted ??= 0;
            IsMemoryManagementPermissionGranted ??= 0;
            IsLocalConsoleLogonRestricted ??= 0;
            IsRemoteLogonGroupManaged ??= 0;
            IsBackupAccessManaged ??= 0;
            IsSystemTimeChangeManaged ??= 0;
            IsAccessTokenCreationLimited ??= 0;
            IsRemoteLogonRestrictedForGuests ??= 0;
            IsScheduledTasksPermissionManaged ??= 0;
            IsLogonAsServicePermissionManaged ??= 0;
            IsGuestLogonManaged ??= 0;
            IsLocalAccountLogonManaged ??= 0;
            IsLogonAsServiceSettingsApplied ??= 0;
            IsRemoteShutdownPermissionManaged ??= 0;
            IsAdministratorUsernameChanged ??= 0;
            IsCachedUsernameCountManaged ??= 0;
            IsPasswordExpirationWarningManaged ??= 0;
            IsAnonymousSIDRequestManaged ??= 0;
            IsNTFSMediaAccessManaged ??= 0;
            IsSharedPrinterDriverInstallationManaged ??= 0;
            IsPrinterSpoolerServiceManaged ??= 0;
            IsOnlineTipManaged ??= 0;
            IsKeepAliveTimeManaged ??= 0;
            IsIRDPOptionDisabled ??= 0;
            IsDataRetransmissionManaged ??= 0;

            var Sum = command.IsPasswordHistoryEnabled + command.IsMaxPasswordAgeConfigured +
                      command.IsMinPasswordAgeConfigured +
                      command.IsMinPasswordLengthConfigured + command.IsComplexPasswordRequired +
                      command.IsPlainTextPasswordStorageDisabled +
                      command.IsAccountLockoutDurationConfigured + command.IsFailedLogonAttemptsLimited +
                      command.IsAdminLockoutConfigured +
                      command.IsPasswordResetErrorCountConfigured + command.IsUserAccountManagementRestricted +
                      command.IsRemoteAccessManaged +
                      command.IsOSAccountAccessLimited + command.IsDomainJoinRestricted +
                      command.IsMemoryManagementPermissionGranted + command.IsLocalConsoleLogonRestricted +
                      command.IsRemoteLogonGroupManaged + command.IsBackupAccessManaged +
                      command.IsSystemTimeChangeManaged +
                      command.IsAccessTokenCreationLimited + command.IsRemoteLogonRestrictedForGuests +
                      command.IsScheduledTasksPermissionManaged +
                      command.IsLogonAsServicePermissionManaged + command.IsGuestLogonManaged +
                      command.IsLocalAccountLogonManaged + command.IsLogonAsServiceSettingsApplied +
                      command.IsRemoteShutdownPermissionManaged + command.IsAdministratorUsernameChanged +
                      command.IsCachedUsernameCountManaged +
                      command.IsPasswordExpirationWarningManaged + command.IsAnonymousSIDRequestManaged +
                      command.IsNTFSMediaAccessManaged +
                      command.IsSharedPrinterDriverInstallationManaged + command.IsPrinterSpoolerServiceManaged +
                      command.IsOnlineTipManaged +
                      command.IsKeepAliveTimeManaged + command.IsIRDPOptionDisabled +
                      command.IsDataRetransmissionManaged;

            var Avg = ((double)Sum / 38);
            var Average = Math.Round(Avg, 2);
            AverageWin2019 = Average;
        }

        }
}
