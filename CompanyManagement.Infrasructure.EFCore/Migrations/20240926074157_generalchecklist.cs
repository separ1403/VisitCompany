using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class generalchecklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessControlStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AccessControlStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AccessManagementStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AccessManagementStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AntivirusStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AntivirusStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AuthenticationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AuthenticationStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AverageGeneral",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "BackupStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "BackupStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "BusinessIdentificationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "BusinessIdentificationStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CCTVStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CCTVStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ClockSynchronizationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ClockSynchronizationStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ComplianceManagementStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ComplianceManagementStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CyberAttackResponseStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CyberAttackResponseStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DataDestructionStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DataDestructionStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DataSalesTradeStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DataSalesTradeStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DevelopmentTestOperationsControlStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DevelopmentTestOperationsControlStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "EmployeeTrainingStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "EmployeeTrainingStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "EntryExitManagementStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "EntryExitManagementStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "FinancialPaymentPlatformStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "FinancialPaymentPlatformStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "HostingServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "HostingServiceStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "IncidentResponseStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "IncidentResponseStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "LogManagementStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "LogManagementStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "NetworkLogicalPhysicalMapStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "NetworkLogicalPhysicalMapStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OrganizationalSecurityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OrganizationalSecurityStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PasswordPolicyStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PasswordPolicyStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PersonnelHiringStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PersonnelHiringStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PhysicalAssetsInventoryStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PhysicalAssetsInventoryStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PublicComplaintsStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PublicComplaintsStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "RemoteAdministrativeAccessStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "RemoteAdministrativeAccessStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecureCodingConfigStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecureCodingConfigStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityChangeApprovalStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityChangeApprovalStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityEvaluationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityEvaluationStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityManagerStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityManagerStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityPolicyStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SecurityPolicyStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SessionExpirationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "SessionExpirationStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ThirdPartyServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ThirdPartyServiceStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "UpdateStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "UpdateStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "UserDataCollectionStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "UserDataCollectionStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "WirelessNetworkStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "WirelessNetworkStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ZoningStatus",
                table: "Checklists");

            migrationBuilder.RenameColumn(
                name: "ZoningStatusScore",
                table: "Checklists",
                newName: "GeneralChecklistID");

            migrationBuilder.AlterColumn<long>(
                name: "IsUserAccountManagementRestricted",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsSystemTimeChangeManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsSharedPrinterDriverInstallationManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsScheduledTasksPermissionManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRemoteShutdownPermissionManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRemoteLogonRestrictedForGuests",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRemoteLogonGroupManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRemoteAccessManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPrinterSpoolerServiceManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPlainTextPasswordStorageDisabled",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPasswordResetErrorCountConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPasswordHistoryEnabled",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPasswordExpirationWarningManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsOnlineTipManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsOSAccountAccessLimited",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsNTFSMediaAccessManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsMinPasswordLengthConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsMinPasswordAgeConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsMemoryManagementPermissionGranted",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsMaxPasswordAgeConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsLogonAsServiceSettingsApplied",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsLogonAsServicePermissionManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsLocalConsoleLogonRestricted",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsLocalAccountLogonManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsKeepAliveTimeManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsIRDPOptionDisabled",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsGuestLogonManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsFailedLogonAttemptsLimited",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsDomainJoinRestricted",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsDataRetransmissionManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsComplexPasswordRequired",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsCachedUsernameCountManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsBackupAccessManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAnonymousSIDRequestManaged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAdministratorUsernameChanged",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAdminLockoutConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAccountLockoutDurationConfigured",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAccessTokenCreationLimited",
                table: "Win2019s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageWin2019",
                table: "Win2019s",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<long>(
                name: "IsUSBPortDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRootLoginDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsRootLoginAuxDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsResetButtonDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsPasswordRecoveryDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsLCDMenuDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsDiagnosticPortDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsCraftInterfaceDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsConsolePortSecured",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsConfigFileEncrypted",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAuxiliaryPortDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreUnusedInterfacesDisabled",
                table: "JuniperHardenings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageJuniper",
                table: "JuniperHardenings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<long>(
                name: "IsUEFISecurityConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsTPMEnabledAndRO",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsTPMConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsServerNameAndFQDNSet",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsSecureBootConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsEncryptionConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsDiskAndRaidConfigDeletionDisabled",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IsAccountServiceConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreUserCertificatesConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreSystemCertificatesConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreSSHKeysEnabled",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreProvisioningSettingsDeleted",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreNetworkSettingsForILOConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreInitialSettingsForILOConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreInitialILOSettingsConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreILOPortAndUSBPortConfigured",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreAppropriateUsernamesCreated",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AreAppropriateGroupsCreated",
                table: "HPEDL380s",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageHpedl380",
                table: "HPEDL380s",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeValidateMobile",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralChecklists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationalSecurityStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationalSecurityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityManagerStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SecurityManagerStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityPolicyStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SecurityPolicyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityChangeApprovalStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SecurityChangeApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartyServiceStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    ThirdPartyServiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonnelHiringStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    PersonnelHiringStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessManagementStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    AccessManagementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplianceManagementStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    ComplianceManagementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentResponseStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    IncidentResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworkLogicalPhysicalMapStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    NetworkLogicalPhysicalMapStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalAssetsInventoryStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    PhysicalAssetsInventoryStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoningStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    ZoningStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessControlStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    AccessControlStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopmentTestOperationsControlStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    DevelopmentTestOperationsControlStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoteAdministrativeAccessStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    RemoteAdministrativeAccessStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecureCodingConfigStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SecureCodingConfigStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityEvaluationStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SecurityEvaluationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackupStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    BackupStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionExpirationStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    SessionExpirationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntivirusStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    AntivirusStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    UpdateStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WirelessNetworkStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    WirelessNetworkStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordPolicyStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    PasswordPolicyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDestructionStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    DataDestructionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogManagementStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    LogManagementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClockSynchronizationStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    ClockSynchronizationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticationStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    AuthenticationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessIdentificationStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    BusinessIdentificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryExitManagementStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    EntryExitManagementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCTVStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    CCTVStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostingServiceStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    HostingServiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivacyPolicyStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    PrivacyPolicyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicComplaintsStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    PublicComplaintsStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CyberAttackResponseStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    CyberAttackResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSalesTradeStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    DataSalesTradeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialPaymentPlatformStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    FinancialPaymentPlatformStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDataCollectionStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    UserDataCollectionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeTrainingStatusScore = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeTrainingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageGeneral = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralChecklists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_GeneralChecklistID",
                table: "Checklists",
                column: "GeneralChecklistID",
                unique: true,
                filter: "[GeneralChecklistID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_GeneralChecklists_GeneralChecklistID",
                table: "Checklists",
                column: "GeneralChecklistID",
                principalTable: "GeneralChecklists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_GeneralChecklists_GeneralChecklistID",
                table: "Checklists");

            migrationBuilder.DropTable(
                name: "GeneralChecklists");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_GeneralChecklistID",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AverageWin2019",
                table: "Win2019s");

            migrationBuilder.DropColumn(
                name: "AverageJuniper",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "AverageHpedl380",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CodeValidateMobile",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "GeneralChecklistID",
                table: "Checklists",
                newName: "ZoningStatusScore");

            migrationBuilder.AlterColumn<bool>(
                name: "IsUserAccountManagementRestricted",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSystemTimeChangeManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSharedPrinterDriverInstallationManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsScheduledTasksPermissionManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoteShutdownPermissionManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoteLogonRestrictedForGuests",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoteLogonGroupManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoteAccessManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrinterSpoolerServiceManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPlainTextPasswordStorageDisabled",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPasswordResetErrorCountConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPasswordHistoryEnabled",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPasswordExpirationWarningManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOnlineTipManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOSAccountAccessLimited",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNTFSMediaAccessManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMinPasswordLengthConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMinPasswordAgeConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMemoryManagementPermissionGranted",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMaxPasswordAgeConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLogonAsServiceSettingsApplied",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLogonAsServicePermissionManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocalConsoleLogonRestricted",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocalAccountLogonManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsKeepAliveTimeManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsIRDPOptionDisabled",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsGuestLogonManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFailedLogonAttemptsLimited",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDomainJoinRestricted",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDataRetransmissionManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsComplexPasswordRequired",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCachedUsernameCountManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsBackupAccessManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAnonymousSIDRequestManaged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdministratorUsernameChanged",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdminLockoutConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccountLockoutDurationConfigured",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccessTokenCreationLimited",
                table: "Win2019s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsUSBPortDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRootLoginDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRootLoginAuxDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsResetButtonDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPasswordRecoveryDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLCDMenuDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDiagnosticPortDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCraftInterfaceDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsConsolePortSecured",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfigFileEncrypted",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAuxiliaryPortDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreUnusedInterfacesDisabled",
                table: "JuniperHardenings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsUEFISecurityConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTPMEnabledAndRO",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTPMConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsServerNameAndFQDNSet",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSecureBootConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEncryptionConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDiskAndRaidConfigDeletionDisabled",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccountServiceConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreUserCertificatesConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreSystemCertificatesConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreSSHKeysEnabled",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreProvisioningSettingsDeleted",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreNetworkSettingsForILOConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreInitialSettingsForILOConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreInitialILOSettingsConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreILOPortAndUSBPortConfigured",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreAppropriateUsernamesCreated",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AreAppropriateGroupsCreated",
                table: "HPEDL380s",
                type: "bit",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessControlStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccessControlStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessManagementStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccessManagementStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AntivirusStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AntivirusStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuthenticationStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageGeneral",
                table: "Checklists",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "BackupStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BackupStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdentificationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BusinessIdentificationStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CCTVStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CCTVStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClockSynchronizationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClockSynchronizationStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplianceManagementStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ComplianceManagementStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyberAttackResponseStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CyberAttackResponseStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataDestructionStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DataDestructionStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataSalesTradeStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DataSalesTradeStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentTestOperationsControlStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DevelopmentTestOperationsControlStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeTrainingStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeTrainingStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryExitManagementStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EntryExitManagementStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialPaymentPlatformStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FinancialPaymentPlatformStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostingServiceStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HostingServiceStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentResponseStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IncidentResponseStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogManagementStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LogManagementStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkLogicalPhysicalMapStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NetworkLogicalPhysicalMapStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationalSecurityStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrganizationalSecurityStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordPolicyStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PasswordPolicyStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonnelHiringStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PersonnelHiringStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAssetsInventoryStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhysicalAssetsInventoryStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivacyPolicyStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrivacyPolicyStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicComplaintsStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PublicComplaintsStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteAdministrativeAccessStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RemoteAdministrativeAccessStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecureCodingConfigStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecureCodingConfigStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityChangeApprovalStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityChangeApprovalStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityEvaluationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityEvaluationStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityManagerStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityManagerStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityPolicyStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityPolicyStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionExpirationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SessionExpirationStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdPartyServiceStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ThirdPartyServiceStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdateStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDataCollectionStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserDataCollectionStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WirelessNetworkStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WirelessNetworkStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZoningStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
