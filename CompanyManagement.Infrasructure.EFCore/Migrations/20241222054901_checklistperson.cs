using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class checklistperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Checklists_ChecklistId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "ChecklistId",
                table: "Persons",
                newName: "CheklistId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_ChecklistId",
                table: "Persons",
                newName: "IX_Persons_CheklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Checklists_CheklistId",
                table: "Persons",
                column: "CheklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Checklists_CheklistId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "CheklistId",
                table: "Persons",
                newName: "ChecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CheklistId",
                table: "Persons",
                newName: "IX_Persons_ChecklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Checklists_ChecklistId",
                table: "Persons",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
