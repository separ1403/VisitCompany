using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class rasmio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CapitalRasm",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EdareKolRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCodeRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationDateRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNoRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumberRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VahedSabtiRasm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CapitalRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EdareKolRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastUpdateRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PostalCodeRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RegistrationDateRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RegistrationNoRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StatusRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TaxNumberRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TitleRasm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "VahedSabtiRasm",
                table: "Companies");
        }
    }
}
