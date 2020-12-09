using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiTemp1.Migrations
{
    public partial class Mvc_Dot_Net : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fakultets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstinas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstinas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpstinaID = table.Column<int>(type: "int", nullable: false),
                    FakultetID = table.Column<int>(type: "int", nullable: false),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Fakultets_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "Fakultets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Opstinas_OpstinaID",
                        column: x => x.OpstinaID,
                        principalTable: "Opstinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_FakultetID",
                table: "Students",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OpstinaID",
                table: "Students",
                column: "OpstinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Fakultets");

            migrationBuilder.DropTable(
                name: "Opstinas");
        }
    }
}
