using CUD.Modele;
using CUD.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry
using Microsoft.Data.SqlClient; // SqlParameter

LectureDbSet();
// Validations();
//AttachementContexte();
//AjoutGraphObjets();
//CmdeSql();
Console.Read();

static void LectureDbSet()
{
    using var context = new VoyagesDbContext();

    foreach (var voyage in context.Voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");
    }


    Console.WriteLine("Lecture terminée !");
}

static void Validations()
{
    using var context = new VoyagesDbContext();

    try
    {
        // Pas de Destination
        var v1 = new Voyage { CodeVoyage = "V1", CategorieId = 2, Prix = 1000 };
        context.Voyages.Add(v1);

        // Pas de catégorie
        var v2 = new Voyage { CodeVoyage = "V2", Destination = "D2", Prix = 2000 };
        //context.Voyages.Add(v2);
       
        context.SaveChanges();
        Console.WriteLine("Enregistrement terminé.");
    }

    catch (DbUpdateException ex)
    {
        string s = string.Empty;

        foreach (var entry in ex.Entries)
        {
              s += $"erreurs sur {(entry.Entity as Voyage)?.CodeVoyage}\n";
        }

        Console.WriteLine($"Erreurs : {Environment.NewLine} {s}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Autre erreur : {ex.Message}");
    }
}

static void AttachementContexte()
{
    Client client;
    EntityEntry<Client> entry;// using Microsoft.EntityFrameworkCore.ChangeTracking;

    using (var contexte1 = new VoyagesDbContext())
    {
        client = contexte1.Clients.Find(1);
        entry = contexte1.Entry(client);
        Console.WriteLine("State dans Ctx1 : " + entry.State);
    }

    using (var contexte2 = new VoyagesDbContext())
    {
        entry = contexte2.Entry(client);
        Console.WriteLine("State dans Ctx2 avant Attach : " + entry.State);

        contexte2.Clients.Attach(client);
        Console.WriteLine("State dans Ctx2 après Attach : " + entry.State);

        // La modification d'une entité attachée, n'actualise pas la valeur de entry.State
        client.Adresse += " ctx2";
        // Actualiser le state de l'entité
        entry = contexte2.Entry(client);
        Console.WriteLine("State dans Ctx2 après Chgmnt de l'entité : " + entry.State);
        contexte2.SaveChanges();
    }
}
static void AjoutGraphObjets()
{
    // Si l'entité connexe à ajouter est chargée dans le même contexte, son état reste à Unchanged

    // En revanche, si elle provient d'un autre contexte, elle est détachée et son affectation
    // à une pté de navigation d'une entité dont l'état est Added, la fait également passer
    // à l'état Added.
    Categorie categorie;
    using (var contexte1 = new VoyagesDbContext())
    {
        categorie = contexte1.Categories.Find(1);
    }

    using (var contexte2 = new VoyagesDbContext())
    {
        //NOK, car la clé existe
        var newVoyage = new Voyage { CodeVoyage = "V1", Destination = "Creation NOK", Prix = 1000, Categorie = categorie };

        //OK en utilisant la clé externe d'une entité existante
        //var newVoyage = new Voyage { CodeVoyage = "V1", Destination = "Creation OK", Prix = 1000, CategorieId = 2 };

        // Ok pour la création d'un ensemble d'entités liées, car l'ajout d'une entité détachée fait passer le State des entités
        // connexes à Added
        //var newVoyage = new Voyage { CodeVoyage = "V1", Destination = "Creation Graph OK", Prix = 1000, Categorie = new Categorie { LibelleCategorie = "Nouvelle catégorie" } };

        var entry = contexte2.Entry(categorie);
        Console.WriteLine("State categorie : " + entry.State);
        contexte2.Voyages.Add(newVoyage);
        contexte2.SaveChanges();
        Console.WriteLine("Création terminée !");
    }
}

static void CmdeSql()
{
    using var context = new VoyagesDbContext();
    string sql = "INSERT INTO Clients (Nom, Ville) VALUES (@NomClient, @Ville)";

    int n = context.Database.ExecuteSqlRaw(sql,
        new SqlParameter("NomClient", "Cmde SQL"),
        new SqlParameter("Ville", "ExecuteSqlRaw"));

    Console.WriteLine($"{n} Client(s) ajouté(s) !");
}
