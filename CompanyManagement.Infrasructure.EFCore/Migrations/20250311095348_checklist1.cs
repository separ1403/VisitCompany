using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class checklist1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicenceCategory_Companies_CompaniesId",
                table: "CompanyLicenceCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicenceCategory_LicenceCategories_LicenceCategoriesId",
                table: "CompanyLicenceCategory");

            migrationBuilder.RenameColumn(
                name: "LicenceCategoriesId",
                table: "CompanyLicenceCategory",
                newName: "LicenceCategoryId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "CompanyLicenceCategory",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLicenceCategory_LicenceCategoriesId",
                table: "CompanyLicenceCategory",
                newName: "IX_CompanyLicenceCategory_LicenceCategoryId");

            migrationBuilder.AddColumn<long>(
                name: "StateCategoryIds",
                table: "Checklists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_StateCategoryIds",
                table: "Checklists",
                column: "StateCategoryIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_StateCategories_StateCategoryIds",
                table: "Checklists",
                column: "StateCategoryIds",
                principalTable: "StateCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicenceCategory_Companies_CompanyId",
                table: "CompanyLicenceCategory",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicenceCategory_LicenceCategories_LicenceCategoryId",
                table: "CompanyLicenceCategory",
                column: "LicenceCategoryId",
                principalTable: "LicenceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_StateCategories_StateCategoryIds",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicenceCategory_Companies_CompanyId",
                table: "CompanyLicenceCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicenceCategory_LicenceCategories_LicenceCategoryId",
                table: "CompanyLicenceCategory");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_StateCategoryIds",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "StateCategoryIds",
                table: "Checklists");

            migrationBuilder.RenameColumn(
                name: "LicenceCategoryId",
                table: "CompanyLicenceCategory",
                newName: "LicenceCategoriesId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyLicenceCategory",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLicenceCategory_LicenceCategoryId",
                table: "CompanyLicenceCategory",
                newName: "IX_CompanyLicenceCategory_LicenceCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicenceCategory_Companies_CompaniesId",
                table: "CompanyLicenceCategory",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicenceCategory_LicenceCategories_LicenceCategoriesId",
                table: "CompanyLicenceCategory",
                column: "LicenceCategoriesId",
                principalTable: "LicenceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
