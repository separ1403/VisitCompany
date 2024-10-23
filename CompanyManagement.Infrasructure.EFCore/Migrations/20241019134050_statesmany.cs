using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class statesmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts",
                column: "StateCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts",
                column: "StateCategoryId",
                unique: true);
        }
    }
}
