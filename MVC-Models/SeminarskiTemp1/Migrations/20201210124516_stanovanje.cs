using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiTemp1.Migrations
{
    public partial class stanovanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sobas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(type: "int", nullable: false),
                    BrojKreveta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stanovanjes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    sobaID = table.Column<int>(type: "int", nullable: false),
                    AkademskaGodina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanovanjes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stanovanjes_Sobas_sobaID",
                        column: x => x.sobaID,
                        principalTable: "Sobas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stanovanjes_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stanovanjes_sobaID",
                table: "Stanovanjes",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Stanovanjes_studentID",
                table: "Stanovanjes",
                column: "studentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stanovanjes");

            migrationBuilder.DropTable(
                name: "Sobas");
        }
    }
}
