using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Infrasructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class checklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePeopleCo",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "PhonePeopleCo",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "RspponsePeopleCo",
                table: "Checklists");

            migrationBuilder.AddColumn<string>(
                name: "FinallDescription",
                table: "Win2019s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Win2019s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FinallDescription",
                table: "JuniperHardenings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "JuniperHardenings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FinallDescription",
                table: "HPEDL380s",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "HPEDL380s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FinallDescription",
                table: "GeneralChecklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "GeneralChecklists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePeopleCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RspponsePeopleCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonePeopleCo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChecklistId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChecklistId",
                table: "Person",
                column: "ChecklistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropColumn(
                name: "FinallDescription",
                table: "Win2019s");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Win2019s");

            migrationBuilder.DropColumn(
                name: "FinallDescription",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "JuniperHardenings");

            migrationBuilder.DropColumn(
                name: "FinallDescription",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "HPEDL380s");

            migrationBuilder.DropColumn(
                name: "FinallDescription",
                table: "GeneralChecklists");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "GeneralChecklists");

            migrationBuilder.AddColumn<string>(
                name: "NamePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhonePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RspponsePeopleCo",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
