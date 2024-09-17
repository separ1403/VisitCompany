using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class tets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreAppropriateGroupsCreateddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreAppropriateUsernamesCreateddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreILOPortAndUSBPortConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreInitialILOSettingsConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreInitialSettingsForILOConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreNetworkSettingsForILOConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreProvisioningSettingsDeleteddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreSSHKeysEnableddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreSystemCertificatesConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreUserCertificatesConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsAccountServiceConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDiskAndRaidConfigDeletionDisableddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsEncryptionConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsSecureBootConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsServerNameAndFQDNSetdescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsTPMConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsTPMEnabledAndROdescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsUEFISecurityConfigureddescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreAppropriateGroupsCreateddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreAppropriateUsernamesCreateddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreILOPortAndUSBPortConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreInitialILOSettingsConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreInitialSettingsForILOConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreNetworkSettingsForILOConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreProvisioningSettingsDeleteddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreSSHKeysEnableddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreSystemCertificatesConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "AreUserCertificatesConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsAccountServiceConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsDiskAndRaidConfigDeletionDisableddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsEncryptionConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsSecureBootConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsServerNameAndFQDNSetdescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsTPMConfigureddescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsTPMEnabledAndROdescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsUEFISecurityConfigureddescription",
                table: "HPEDL380s");
        }
    }
}
