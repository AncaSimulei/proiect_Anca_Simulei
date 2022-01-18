using Microsoft.EntityFrameworkCore.Migrations;

namespace proiect_Anca_Simulei.Migrations
{
    public partial class CategorieVin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomeniuID",
                table: "Vin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Domeniu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDomeniu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domeniu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieVin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieVin_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieVin_Vin_VinID",
                        column: x => x.VinID,
                        principalTable: "Vin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vin_DomeniuID",
                table: "Vin",
                column: "DomeniuID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieVin_CategorieID",
                table: "CategorieVin",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieVin_VinID",
                table: "CategorieVin",
                column: "VinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Domeniu_DomeniuID",
                table: "Vin",
                column: "DomeniuID",
                principalTable: "Domeniu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Domeniu_DomeniuID",
                table: "Vin");

            migrationBuilder.DropTable(
                name: "CategorieVin");

            migrationBuilder.DropTable(
                name: "Domeniu");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Vin_DomeniuID",
                table: "Vin");

            migrationBuilder.DropColumn(
                name: "DomeniuID",
                table: "Vin");
        }
    }
}
