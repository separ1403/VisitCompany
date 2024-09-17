using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Companies_CompanyId",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CountEmployee",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CountFlower",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Licence",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "NameRspponseCo",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Checklists");

            migrationBuilder.AlterColumn<string>(
                name: "NamePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Checklists",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                name: "AccountIds",
                table: "Checklists",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<double>(
                name: "AverageProfessional",
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
                name: "ControllerAuthenticationStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerSecuritySettings",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountEmployees",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountFolowers",
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
                name: "FirmwareCapabilityStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HardwarePortStatus",
                table: "Checklists",
                type: "nvarchar(max)",
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
                name: "NtpServiceStatus",
                table: "Checklists",
                type: "nvarchar(max)",
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
                name: "OsBootType",
                table: "Checklists",
                type: "nvarchar(max)",
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
                name: "PhonePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
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
                name: "RspponsePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreControllerAuthenticationStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreControllerSecuritySettings",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreFirmwareCapabilityStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreHardwarePortStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreNtpServiceStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreOsBootType",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreSgxCapabilityStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreTpm2CapabilityStatus",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScoreTxtCapabilityStatus",
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
                name: "SgxCapabilityStatus",
                table: "Checklists",
                type: "nvarchar(max)",
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
                name: "Title",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tpm2CapabilityStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TxtCapabilityStatus",
                table: "Checklists",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<long>(
                name: "ZoningStatusScore",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Companies_CompanyId",
                table: "Checklists",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Companies_CompanyId",
                table: "Checklists");

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
                name: "AccountIds",
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
                name: "AverageProfessional",
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
                name: "ControllerAuthenticationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ControllerSecuritySettings",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CountEmployees",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "CountFolowers",
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
                name: "FirmwareCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "HardwarePortStatus",
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
                name: "NtpServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OrganizationalSecurityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OrganizationalSecurityStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OsBootType",
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
                name: "PhonePeopleCo",
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
                name: "RspponsePeopleCo",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreControllerAuthenticationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreControllerSecuritySettings",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreFirmwareCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreHardwarePortStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreNtpServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreOsBootType",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreSgxCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreTpm2CapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ScoreTxtCapabilityStatus",
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
                name: "SgxCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ThirdPartyServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ThirdPartyServiceStatusScore",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Tpm2CapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "TxtCapabilityStatus",
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

            migrationBuilder.DropColumn(
                name: "ZoningStatusScore",
                table: "Checklists");

            migrationBuilder.AlterColumn<string>(
                name: "NamePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Checklists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Checklists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CountEmployee",
                table: "Checklists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CountFlower",
                table: "Checklists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Licence",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameRspponseCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Checklists",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Companies_CompanyId",
                table: "Checklists",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
