using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class checklistgeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessControlStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "AccessControlStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "AntivirusStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "AntivirusStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "AuthenticationStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "AuthenticationStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "BackupStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "BackupStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "BusinessIdentificationStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "BusinessIdentificationStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "CCTVStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "CCTVStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "ClockSynchronizationStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "ClockSynchronizationStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "CyberAttackResponseStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "CyberAttackResponseStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DataDestructionStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DataDestructionStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DataSalesTradeStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DataSalesTradeStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DevelopmentTestOperationsControlStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "DevelopmentTestOperationsControlStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "EmployeeTrainingStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "EmployeeTrainingStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "EntryExitManagementStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "EntryExitManagementStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "FinancialPaymentPlatformStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "FinancialPaymentPlatformStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "HostingServiceStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "HostingServiceStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "LogManagementStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "LogManagementStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "NetworkLogicalPhysicalMapStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "NetworkLogicalPhysicalMapStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PasswordPolicyStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PasswordPolicyStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PhysicalAssetsInventoryStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PhysicalAssetsInventoryStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PublicComplaintsStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "PublicComplaintsStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "RemoteAdministrativeAccessStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "RemoteAdministrativeAccessStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SecureCodingConfigStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SecureCodingConfigStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SecurityEvaluationStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SecurityEvaluationStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SessionExpirationStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "SessionExpirationStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "UpdateStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "UpdateStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "UserDataCollectionStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "UserDataCollectionStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "WirelessNetworkStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "WirelessNetworkStatusScore",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "ZoningStatus",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "ZoningStatusScore",
                table: "GeneralChecklists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessControlStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccessControlStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AntivirusStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AntivirusStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AuthenticationStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackupStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BackupStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdentificationStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BusinessIdentificationStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CCTVStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CCTVStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClockSynchronizationStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClockSynchronizationStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyberAttackResponseStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CyberAttackResponseStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataDestructionStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DataDestructionStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataSalesTradeStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DataSalesTradeStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentTestOperationsControlStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DevelopmentTestOperationsControlStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeTrainingStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeTrainingStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryExitManagementStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EntryExitManagementStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialPaymentPlatformStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FinancialPaymentPlatformStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostingServiceStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HostingServiceStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogManagementStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LogManagementStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkLogicalPhysicalMapStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NetworkLogicalPhysicalMapStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordPolicyStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PasswordPolicyStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAssetsInventoryStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhysicalAssetsInventoryStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrivacyPolicyStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PrivacyPolicyStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicComplaintsStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PublicComplaintsStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteAdministrativeAccessStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RemoteAdministrativeAccessStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecureCodingConfigStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecureCodingConfigStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityEvaluationStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SecurityEvaluationStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionExpirationStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SessionExpirationStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdateStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDataCollectionStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserDataCollectionStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WirelessNetworkStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WirelessNetworkStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZoningStatus",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ZoningStatusScore",
                table: "GeneralChecklists",
                type: "bigint",
                nullable: true);
        }
    }
}
