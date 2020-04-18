using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiApi.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameOfRace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    RaceId = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    SkierId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => new { x.Year, x.RaceId });
                    table.ForeignKey(
                        name: "FK_Winners_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winners_Skiers_SkierId",
                        column: x => x.SkierId,
                        principalTable: "Skiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Winners_RaceId",
                table: "Winners",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_SkierId",
                table: "Winners",
                column: "SkierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
