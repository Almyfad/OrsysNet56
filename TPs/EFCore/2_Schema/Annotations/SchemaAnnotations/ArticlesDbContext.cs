using Microsoft.EntityFrameworkCore;
using Modele;

namespace SchemaAnnotations
{
    public class ArticlesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Annotations.ArticlesEFC");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cat1 = new Categorie { CategorieId = 1, LibelleCategorie = "Croisière" };
            var cat2 = new Categorie { CategorieId = 2, LibelleCategorie = "Trekking" };

            var art1 = new Article
            {
                ArticleId = 1,
                Designation = "Australie",
                Description = "L'Australie fascinante avec Sydney et son célèbre opéra ...",
                Prix = 3000,
                CategorieId = 1
            };
            var art2 = new Article
            {
                ArticleId = 2,
                Designation = "Egypte",
                Description = "Au carrefour des civilisations, l'Egypte  ...",
                Prix = 2000,
                CategorieId = 2
            };
            var art3 = new Article
            {
                ArticleId = 3,
                Designation = "Kenya",
                Description = "Une véritable immersion en plein cœur de la vaste savane ...",
                Prix = 1450,
                CategorieId = 2
            };

            var client1 = new Client
            {
                Nom = "Martin",
                Prenom = "Jean",
                Email = "j.martin@mail.com",
                StatutClient = StatutClient.Actif,
                AdresseId = 1
            };
            var client2 = new Client
            {
                Nom = "Clio",
                Prenom = "Suzane",
                Email = "s.clio@mail.com",
                StatutClient = StatutClient.Actif,
                AdresseId = 2
            };

            var adresse1 = new Adresse { AdresseId = 1, Ville = "Lyon" };
            var adresse2 = new Adresse { AdresseId = 2, Ville = "Brest" };
            modelBuilder.Entity<Categorie>().HasData(cat1, cat2);
            modelBuilder.Entity<Article>().HasData(art1, art2, art3);
            modelBuilder.Entity<Adresse>().HasData(adresse1, adresse2);
            modelBuilder.Entity<Client>().HasData(client1, client2);
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
