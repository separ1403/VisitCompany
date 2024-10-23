using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class state : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "StateCategoryId",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "StateCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts",
                column: "StateCategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_StateCategories_StateCategoryId",
                table: "Accounts",
                column: "StateCategoryId",
                principalTable: "StateCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_StateCategories_StateCategoryId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "StateCategories");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StateCategoryId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StateCategoryId",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
