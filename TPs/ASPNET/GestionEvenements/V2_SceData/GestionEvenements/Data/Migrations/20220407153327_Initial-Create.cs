using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEvenements.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Civilite = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnneeNaissance = table.Column<int>(type: "int", nullable: true),
                    AnneeDeces = table.Column<int>(type: "int", nullable: true),
                    LieuNaissance = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Activites = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "TypesEvenement",
                columns: table => new
                {
                    TypeEvenementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesEvenement", x => x.TypeEvenementId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    EvenementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEvenementId = table.Column<int>(type: "int", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    DateEvenement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdresseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.EvenementId);
                    table.ForeignKey(
                        name: "FK_Evenements_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                    table.ForeignKey(
                        name: "FK_Evenements_TypesEvenement_TypeEvenementId",
                        column: x => x.TypeEvenementId,
                        principalTable: "TypesEvenement",
                        principalColumn: "TypeEvenementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    EvenementId = table.Column<int>(type: "int", nullable: false),
                    Commentaires = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => new { x.ParticipantId, x.EvenementId });
                    table.ForeignKey(
                        name: "FK_Participations_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "EvenementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseId", "CodePostal", "Latitude", "Longitude", "Notes", "Pays", "Region", "Rue", "Titre", "Ville" },
                values: new object[,]
                {
                    { 1, "75015", null, null, "Fondation à but non lucratif consacrée à l'étude de la biologie et des micros-organismes.", "France", "Ile de France", "25-28 Rue du Dr Roux", "Institut Pasteur", "Paris" },
                    { 2, null, 47.646388899999998, -122.13500000000001, "Construit en 1986 sur 2 Ha pour plus de 40 000 salariés.", "USA", "Washington", null, "Campus Microsoft", "Redmond" },
                    { 3, null, 37.421900000000001, -122.0838, "Site (parmi 23 aux USA et autant en Europe) principal de la firme.", "Santa Clara", "Californie", null, "Googleplex", "Zee-Town" },
                    { 4, null, 37.481099999999998, -122.1538, "En cours de construction depuis 2012 sur 80 Ha.", "USA", "Californie", null, "Facebook City", "Zee-Town" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "Activites", "AnneeDeces", "AnneeNaissance", "Civilite", "LieuNaissance", "Nom", "Prenom", "Url" },
                values: new object[,]
                {
                    { 1, "L'inventeur de l'imprimerie.", 1468, 1395, 1, "Mayence en Allemagne", "Gutenberg", null, "https://www.histoire-pour-tous.fr/inventions/307-invention-de-imprimerie.html" },
                    { 2, "Inventeur du premier vaccin contre la rage.", 1895, 1822, 1, "Dole", "Pasteur", null, "https://fr.wikipedia.org/wiki/Louis_Pasteur" },
                    { 3, "L'un des principaux inventeurs du Web, fondateur du W3C.", null, 1955, 1, "Londres", "Berners-Lee", "Tim", "https://fr.wikipedia.org/wiki/Tim_Berners-Lee" },
                    { 4, "Fondateur de Microsoft avec Paul Allen.", null, 1955, 1, "Seattle", "Gates", "Bill", "https://fr.wikipedia.org/wiki/Bill_Gates" }
                });

            migrationBuilder.InsertData(
                table: "TypesEvenement",
                columns: new[] { "TypeEvenementId", "Libelle" },
                values: new object[,]
                {
                    { 1, "Scientifique" },
                    { 2, "IT" },
                    { 3, "Culturel" },
                    { 4, "Invention" }
                });

            migrationBuilder.InsertData(
                table: "Evenements",
                columns: new[] { "EvenementId", "AdresseId", "Annee", "DateEvenement", "Description", "Titre", "TypeEvenementId", "Url" },
                values: new object[,]
                {
                    { 1, null, 1455, null, "L'invention de l'imprimerie commence par la publication de la Bible en 1455.", "Invention de l'imprimerie", 4, "https://www.histoire-pour-tous.fr/inventions/307-invention-de-imprimerie.html" },
                    { 2, null, 1769, null, "Le premier véhicule automobile a été créé en 1769 par Joseph Cugnot. Le premier moteur à essence a été créé en 1883 à Rouen par Edouard Delamare-Deboutteville.", "Invention de l'automobile", 4, "https://www.histoire-pour-tous.fr/dossiers/168-histoire-des-inventions-les-transports-terrestres.html" },
                    { 3, null, 1876, null, null, "Invention du téléphone par Alexander Graham Bell", 1, "https://fr.wikipedia.org/wiki/Téléphone" },
                    { 4, 1, 1885, null, "Invention du premier vaccin contre la rage.", "Invention du vaccin", 1, "https://fr.wikipedia.org/wiki/Louis_Pasteur" },
                    { 5, null, 1897, null, "Inventé par Karl Ferdinand Braun, la télévision couleur voit le jour en 1928.", "Le premier tube cathodique", 4, "https://fr.wikipedia.org/wiki/Télévision" },
                    { 6, null, 1903, null, "Le premier vol motorisé.", "Début de l'aviation", 4, "https://fr.wikipedia.org/wiki/Histoire_de_laviation" },
                    { 7, null, 1969, null, "Neil Armstrong pose le pied sur la lune lors de la mission Apollo 11.", "Le premier pas sur la lune", 4, "https://fr.wikipedia.org/wiki/Apollo_11" },
                    { 8, null, 1975, null, "MS est créé par Bill Gates et Paul Allen qui lance MS-DOS, Windows, Office puis .NET en 2002. Apple est créé l'année suivante par Steve Jobs.", "Le lancement du PC", 4, "https://fr.wikipedia.org/wiki/Microsoft" },
                    { 9, null, 1990, null, "Les bases sont créées dans le cadre du projet ARPANET dans les années 60. Le protocole HTTP est développé au CERN par Tim Berners-Lee et Robert Cailliau dans les années 90", "Le lancement d'Internet", 4, "https://fr.wikipedia.org/wiki/Internet" },
                    { 10, 3, 1998, null, "Google est créé dans la Silicon Valleypar Larry Page et Sergey Brin.", "Le lancement de Google", 2, "https://fr.wikipedia.org/wiki/Google" },
                    { 11, 4, 2006, null, "Mark Zuckerberg développe son réseau qui s'ouvre au public qui atteint 2 mds d'utilisdateurs en 2017.", "Les réseaux sociaux", 2, "https://fr.wikipedia.org/wiki/Facebook" },
                    { 12, null, 2007, null, "L'iPhone est lancé avec une interface tactile et un ensemble des services connectés qui vont devenir Apple Store.", "La mobilité", 2, "https://fr.wikipedia.org/wiki/Apple" },
                    { 13, 2, 2016, null, ".NET devient multi-plateformes et Open Source.", ".NET Core", 2, "https://dotnet.microsoft.com/platform/support/policy/dotnet-core" },
                    { 14, 2, 2020, null, ".NET 5 fusionne le Framework .NET et Core avec un sous-ensemble commun dénommé .NET Standard.", ".NET 5", 2, "https://dotnet.microsoft.com/platform/support/policy/dotnet-core" }
                });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "EvenementId", "ParticipantId", "Commentaires" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 4, 2, null },
                    { 9, 3, null },
                    { 8, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_AdresseId",
                table: "Evenements",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_TypeEvenementId",
                table: "Evenements",
                column: "TypeEvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_EvenementId",
                table: "Participations",
                column: "EvenementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "TypesEvenement");
        }
    }
}
