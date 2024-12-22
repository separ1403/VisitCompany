using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountChecklist_Accounts_AccountsId",
                table: "AccountChecklist");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountChecklist_Checklists_ChecklistsId",
                table: "AccountChecklist");

            migrationBuilder.DropColumn(
                name: "Average",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ChecklistsId",
                table: "AccountChecklist",
                newName: "ChecklistId");

            migrationBuilder.RenameColumn(
                name: "AccountsId",
                table: "AccountChecklist",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountChecklist_ChecklistsId",
                table: "AccountChecklist",
                newName: "IX_AccountChecklist_ChecklistId");

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "Win2019s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferDateFrom",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferDateTo",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountChecklist_Accounts_AccountId",
                table: "AccountChecklist",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountChecklist_Checklists_ChecklistId",
                table: "AccountChecklist",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountChecklist_Accounts_AccountId",
                table: "AccountChecklist");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountChecklist_Checklists_ChecklistId",
                table: "AccountChecklist");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "Win2019s");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CheckDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ReferDateFrom",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ReferDateTo",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ChecklistId",
                table: "AccountChecklist",
                newName: "ChecklistsId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountChecklist",
                newName: "AccountsId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountChecklist_ChecklistId",
                table: "AccountChecklist",
                newName: "IX_AccountChecklist_ChecklistsId");

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Average",
                table: "Companies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountChecklist_Accounts_AccountsId",
                table: "AccountChecklist",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountChecklist_Checklists_ChecklistsId",
                table: "AccountChecklist",
                column: "ChecklistsId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
