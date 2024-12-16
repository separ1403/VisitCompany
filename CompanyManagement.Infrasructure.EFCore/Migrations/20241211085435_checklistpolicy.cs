using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class checklistpolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GeneralChecklistPolicyID",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GeneralChecklistProfessionalID",
                table: "Checklists",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralPolicies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    AverageGeneralPolicy = table.Column<double>(type: "float", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    FinallDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralProffesionals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    AverageGeneralProffesional = table.Column<double>(type: "float", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    FinallDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralProffesionals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_GeneralChecklistPolicyID",
                table: "Checklists",
                column: "GeneralChecklistPolicyID",
                unique: true,
                filter: "[GeneralChecklistPolicyID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_GeneralChecklistProfessionalID",
                table: "Checklists",
                column: "GeneralChecklistProfessionalID",
                unique: true,
                filter: "[GeneralChecklistProfessionalID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_GeneralPolicies_GeneralChecklistPolicyID",
                table: "Checklists",
                column: "GeneralChecklistPolicyID",
                principalTable: "GeneralPolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_GeneralProffesionals_GeneralChecklistProfessionalID",
                table: "Checklists",
                column: "GeneralChecklistProfessionalID",
                principalTable: "GeneralProffesionals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_GeneralPolicies_GeneralChecklistPolicyID",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_GeneralProffesionals_GeneralChecklistProfessionalID",
                table: "Checklists");

            migrationBuilder.DropTable(
                name: "GeneralPolicies");

            migrationBuilder.DropTable(
                name: "GeneralProffesionals");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_GeneralChecklistPolicyID",
                table: "Checklists");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_GeneralChecklistProfessionalID",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "GeneralChecklistPolicyID",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "GeneralChecklistProfessionalID",
                table: "Checklists");
        }
    }
}
