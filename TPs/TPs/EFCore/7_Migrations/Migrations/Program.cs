
using Migrations.Modele;

using (var context = new VoyagesDbContext())
{
    context.Database.EnsureCreated();
    foreach (var voyage in context.Voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");
    }
}

Console.WriteLine("Lecture terminée !");
Console.Read();