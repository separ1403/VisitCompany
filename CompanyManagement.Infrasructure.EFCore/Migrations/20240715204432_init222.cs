using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreUnusedInterfacesDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsAuxiliaryPortDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsConfigFileEncrypteddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsConsolePortSecureddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsCraftInterfaceDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDiagnosticPortDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsLCDMenuDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsPasswordRecoveryDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsResetButtonDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsRootLoginAuxDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsRootLoginDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsUSBPortDisableddescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreUnusedInterfacesDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsAuxiliaryPortDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsConfigFileEncrypteddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsConsolePortSecureddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsCraftInterfaceDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsDiagnosticPortDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsLCDMenuDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsPasswordRecoveryDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsResetButtonDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsRootLoginAuxDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsRootLoginDisableddescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsUSBPortDisableddescription",
                table: "JuniperHardenings");
        }
    }
}
