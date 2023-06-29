using System;
using Microsoft.EntityFrameworkCore;
using Modele;

namespace Hierarchie
{
    public class HierarchieDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Hierarchie.ArticlesEFC");
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
            var promo1 = new Promotion
            {
                ArticleId = 3,
                Designation = "Kenya",
                Description = "Une véritable immersion en plein cœur de la vaste savane ...",
                Prix = 1450,
                CategorieId = 2,
                DateDebut= DateTime.Now,
                DateFin = DateTime.Now.AddMonths(1)
            };
        
            modelBuilder.Entity<Categorie>().HasData(cat1, cat2);
            modelBuilder.Entity<Article>().HasData(art1, art2);
            modelBuilder.Entity<Promotion>().HasData(promo1);
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
