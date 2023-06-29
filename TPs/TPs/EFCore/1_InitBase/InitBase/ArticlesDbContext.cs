using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modele;

namespace InitBase
{
    public class ArticlesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=ArticlesEFC");

            // PN Microsoft.Extensions.Configuration.Json pour ConfigurationBuilder
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = configBuilder.Build();
            string cs = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(cs);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cat1 = new Categorie { CategorieId=1, LibelleCategorie = "Croisière" };
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

            modelBuilder.Entity<Categorie>().HasData(cat1,cat2);
            modelBuilder.Entity<Article>().HasData(art1, art2, art3);
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
