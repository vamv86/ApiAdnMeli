using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAdn",
                columns: table => new
                {
                    TblAdnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMutant = table.Column<bool>(type: "bit", nullable: false),
                    AdnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAdn", x => x.TblAdnId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAdn_Adn",
                table: "TblAdn",
                column: "Adn");

            migrationBuilder.CreateIndex(
                name: "IX_TblAdn_IsMutant",
                table: "TblAdn",
                column: "IsMutant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAdn");
        }
    }
}
