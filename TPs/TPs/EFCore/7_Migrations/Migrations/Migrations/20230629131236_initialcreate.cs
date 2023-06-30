using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleCategorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Civilite = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ModesReservations",
                columns: table => new
                {
                    ModeReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleModeReservation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModesReservations", x => x.ModeReservationId);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    CodeVoyage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValueSql: "((0))"),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Prix = table.Column<decimal>(type: "money", nullable: false),
                    Promotion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.CodeVoyage);
                    table.ForeignKey(
                        name: "FK_Voyages_Categories",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId");
                });

            migrationBuilder.CreateTable(
                name: "Croisieres",
                columns: table => new
                {
                    CodeVoyage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NbrJours = table.Column<int>(type: "int", nullable: false),
                    PrixJour = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Croisieres_", x => x.CodeVoyage);
                    table.ForeignKey(
                        name: "FK_Croisieres_Voyages",
                        column: x => x.CodeVoyage,
                        principalTable: "Voyages",
                        principalColumn: "CodeVoyage");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CodeVoyage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Qte = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    DateReservation = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "money", nullable: false),
                    ModeReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Reservations_ModesReservations",
                        column: x => x.ModeReservation,
                        principalTable: "ModesReservations",
                        principalColumn: "ModeReservationId");
                    table.ForeignKey(
                        name: "FK_Reservations_Voyages",
                        column: x => x.CodeVoyage,
                        principalTable: "Voyages",
                        principalColumn: "CodeVoyage");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CodeVoyage",
                table: "Reservations",
                column: "CodeVoyage");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ModeReservation",
                table: "Reservations",
                column: "ModeReservation");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_CategorieId",
                table: "Voyages",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Croisieres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ModesReservations");

            migrationBuilder.DropTable(
                name: "Voyages");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
