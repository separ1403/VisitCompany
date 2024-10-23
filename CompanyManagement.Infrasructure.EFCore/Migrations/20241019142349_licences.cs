using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class licences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "LicenceIds",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenceIds",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "LicenceId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
