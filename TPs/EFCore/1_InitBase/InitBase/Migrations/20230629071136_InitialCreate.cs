using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Promotion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "LibelleCategorie" },
                values: new object[] { 1, "Croisière" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "LibelleCategorie" },
                values: new object[] { 2, "Trekking" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategorieId", "Description", "Designation", "Prix", "Promotion" },
                values: new object[] { 1, 1, "L'Australie fascinante avec Sydney et son célèbre opéra ...", "Australie", 3000m, false });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategorieId", "Description", "Designation", "Prix", "Promotion" },
                values: new object[] { 2, 2, "Au carrefour des civilisations, l'Egypte  ...", "Egypte", 2000m, false });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategorieId", "Description", "Designation", "Prix", "Promotion" },
                values: new object[] { 3, 2, "Une véritable immersion en plein cœur de la vaste savane ...", "Kenya", 1450m, false });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategorieId",
                table: "Articles",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
