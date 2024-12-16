using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StateCategoryIds",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StateCategoryIds",
                table: "Companies",
                column: "StateCategoryIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_StateCategories_StateCategoryIds",
                table: "Companies",
                column: "StateCategoryIds",
                principalTable: "StateCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_StateCategories_StateCategoryIds",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StateCategoryIds",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StateCategoryIds",
                table: "Companies");
        }
    }
}
