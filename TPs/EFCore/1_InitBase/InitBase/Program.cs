using InitBase.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace InitBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ArticlesDbContext())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
                foreach (var article in context.Articles)
                {
                    Console.WriteLine($"{article.ArticleId} {article.Designation}");
                }
            }

            Console.WriteLine("Lecture terminée !");
            Console.Read();
        }
    }
}
