using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitBase.Migrations
{
    public partial class promotion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "debut",
                table: "Articles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fin",
                table: "Articles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategorieId", "Description", "Designation", "Discriminator", "Prix" },
                values: new object[,]
                {
                    { 1, 1, "L'Australie fascinante avec Sydney et son célèbre opéra ...", "Australie", "Article", 3000m },
                    { 2, 2, "Au carrefour des civilisations, l'Egypte  ...", "Egypte", "Article", 2000m },
                    { 3, 2, "Une véritable immersion en plein cœur de la vaste savane ...", "Kenya", "Article", 1450m }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "CategorieId", "Description", "Designation", "Discriminator", "Prix", "debut", "fin" },
                values: new object[] { 4, 2, "Une véritable immersion en plein cœur de la vaste savane ...", "Kenya PROMO", "Promotion", 1450m, new DateTime(2023, 6, 29, 10, 34, 18, 807, DateTimeKind.Local).AddTicks(63), new DateTime(2023, 7, 29, 10, 34, 18, 807, DateTimeKind.Local).AddTicks(73) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "debut",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "fin",
                table: "Articles");
        }
    }
}
