using System;
using System.Linq;
using Modele;

namespace Hierarchie
{
    class Program
    {
        static void Main(string[] args)
        {
            new HierarchieDbContext().Database.EnsureCreated();
            LireBase();
            LirePromotions();
            LireArticles();
        }

        static void LireBase()
        {
            using (var ctx = new HierarchieDbContext())
            {

                Console.WriteLine("Articles :");
                var articles = ctx.Articles.ToList();
                foreach (Article article in articles)
                {
                    Console.WriteLine("* Article {0} - {1}", article.ArticleId, article.Designation);
                }
            }

            Console.WriteLine("Lecture terminée !");
            Console.Read();
        }
        static void LirePromotions()
        {
            using (var ctx = new HierarchieDbContext())
            {
                Console.WriteLine("Promotions :");
                var promos = ctx.Articles.OfType<Promotion>().ToList();
                foreach (Promotion promo in promos)
                {
                    Console.WriteLine("* Article {0} - {1} du {2} au {3}", promo.ArticleId, promo.Designation, promo.DateDebut, promo.DateFin);
                }
            }

            Console.WriteLine("Lecture terminée !");
            Console.Read();
        }

        static void LireArticles()
        {
            using (var ctx = new HierarchieDbContext())
            {
                Console.WriteLine("Articles :");
                var articles = ctx.Articles.Where(a =>  !(a is Promotion)).ToList();
                foreach (Article article in articles)
                {
                    Console.WriteLine("* Article {0} - {1}", article.ArticleId, article.Designation);
                }
            }

            Console.WriteLine("Lecture terminée !");
            Console.Read();
        }
    }
}
