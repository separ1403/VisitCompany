using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageProfessional",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ControllerAuthenticationStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "ControllerSecuritySettings",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "FirmwareCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "HardwarePortStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "NtpServiceStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "OsBootType",
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
                name: "SgxCapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "Tpm2CapabilityStatus",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "TxtCapabilityStatus",
                table: "Checklists");

            migrationBuilder.RenameColumn(
                name: "ScoreTxtCapabilityStatus",
                table: "Checklists",
                newName: "JuniperHardeningID");

            migrationBuilder.RenameColumn(
                name: "ScoreTpm2CapabilityStatus",
                table: "Checklists",
                newName: "HPEDL380ID");

            migrationBuilder.CreateTable(
                name: "HPEDL380s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTPMEnabledAndRO = table.Column<bool>(type: "bit", nullable: false),
                    AreAppropriateUsernamesCreated = table.Column<bool>(type: "bit", nullable: false),
                    AreAppropriateGroupsCreated = table.Column<bool>(type: "bit", nullable: false),
                    AreNetworkSettingsForILOConfigured = table.Column<bool>(type: "bit", nullable: false),
                    AreInitialSettingsForILOConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsServerNameAndFQDNSet = table.Column<bool>(type: "bit", nullable: false),
                    IsAccountServiceConfigured = table.Column<bool>(type: "bit", nullable: false),
                    AreILOPortAndUSBPortConfigured = table.Column<bool>(type: "bit", nullable: false),
                    AreSSHKeysEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AreUserCertificatesConfigured = table.Column<bool>(type: "bit", nullable: false),
                    AreSystemCertificatesConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsEncryptionConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsUEFISecurityConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsSecureBootConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsTPMConfigured = table.Column<bool>(type: "bit", nullable: false),
                    AreInitialILOSettingsConfigured = table.Column<bool>(type: "bit", nullable: false),
                    IsDiskAndRaidConfigDeletionDisabled = table.Column<bool>(type: "bit", nullable: false),
                    AreProvisioningSettingsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HPEDL380s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JuniperHardenings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsConsolePortSecured = table.Column<bool>(type: "bit", nullable: false),
                    IsRootLoginDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsPasswordRecoveryDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsAuxiliaryPortDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsRootLoginAuxDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDiagnosticPortDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsUSBPortDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsCraftInterfaceDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsLCDMenuDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsResetButtonDisabled = table.Column<bool>(type: "bit", nullable: false),
                    AreUnusedInterfacesDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsConfigFileEncrypted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuniperHardenings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_HPEDL380ID",
                table: "Checklists",
                column: "HPEDL380ID",
                unique: true,
                filter: "[HPEDL380ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_JuniperHardeningID",
                table: "Checklists",
                column: "JuniperHardeningID",
                unique: true,
                filter: "[JuniperHardeningID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_HPEDL380s_HPEDL380ID",
                table: "Checklists",
                column: "HPEDL380ID",
                principalTable: "HPEDL380s",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_JuniperHardenings_JuniperHardeningID",
                table: "Checklists",
                column: "JuniperHardeningID",
                principalTable: "JuniperHardenings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_HPEDL380s_HPEDL380ID",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_JuniperHardenings_JuniperHardeningID",
                table: "Checklists");

            migrationBuilder.DropTable(
                name: "HPEDL380s");

            migrationBuilder.DropTable(
                name: "JuniperHardenings");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_HPEDL380ID",
                table: "Checklists");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_JuniperHardeningID",
                table: "Checklists");

            migrationBuilder.RenameColumn(
                name: "JuniperHardeningID",
                table: "Checklists",
                newName: "ScoreTxtCapabilityStatus");

            migrationBuilder.RenameColumn(
                name: "HPEDL380ID",
                table: "Checklists",
                newName: "ScoreTpm2CapabilityStatus");

            migrationBuilder.AddColumn<double>(
                name: "AverageProfessional",
                table: "Checklists",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                name: "NtpServiceStatus",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OsBootType",
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

            migrationBuilder.AddColumn<string>(
                name: "SgxCapabilityStatus",
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
        }
    }
}
