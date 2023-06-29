using System;
using System.Linq;
using Modele;
namespace SchemaFluent
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ArticlesDbContext())
            {
                ctx.Database.EnsureCreated();
                Console.WriteLine("Articles :");
                var articles = ctx.Articles.ToList();
                foreach (Article article in articles)
                {
                    Console.WriteLine("* Article {0} - {1}", article.ArticleId, article.Designation);
                }

                Console.WriteLine("Client :");
                var clients = ctx.Clients.ToList();
                foreach (Client client in clients)
                {
                    Console.WriteLine("* Client {0}", client);
                }
            }

            Console.WriteLine("Lecture terminée !");
            Console.Read();
        }
    }
}

