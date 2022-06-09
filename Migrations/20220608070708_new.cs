using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe11.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VærMelding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dato = table.Column<DateTime>(type: "datetime", nullable: true),
                    Temperatur = table.Column<int>(type: "int", nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bruker = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VærMelding", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VærMelding");
        }
    }
}
