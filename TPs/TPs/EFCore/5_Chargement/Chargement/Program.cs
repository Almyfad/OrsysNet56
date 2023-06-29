using Chargement.Modele;
using Chargement.Dal;
using Microsoft.EntityFrameworkCore;

LectureDbSet();
//LectureQueryable();
//AsyncAwait();
//DonnesLocales();
//MethodeFind();
//ChargementReferences();
//LazyLoading();
//EagerLoading();
//EagerLoadingFiltre();
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

static void LectureQueryable()
{
    using var context = new VoyagesDbContext();
    
	var req = context.Clients.Where(it => it.Ville == "Brest");
	var resultat = req.ToList();
	
	foreach (var client in req)
	{
		Console.WriteLine($"{client.Prenom} {client.Nom} {client.Ville}");
	}

	Console.WriteLine($"{req.Count()} lignes chargées");
}

static void AsyncAwait()
{
    using var context = new VoyagesDbContext();
    
	List<Voyage> liste = context.Voyages.ToList();
	
	foreach (var voyage in liste)
	{
		Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");
	}    
}

static void DonnesLocales()
{
    using var context = new VoyagesDbContext();

	// Charger les données du DbSet en mémoire
	var req = context.Voyages.Where(v => v.CategorieId == 3).Load();

	// Plus de requêtage en base avec Local qui référence les entités chargées en mémoire
	Console.WriteLine($"{context.Voyages.Local.Count} lignes chargées en mémoire");

	Console.WriteLine("Parcours des données chargées en mémoire :");
	foreach (Voyage v in context.Voyages.Local)
	{
		Console.WriteLine($"> {v.CodeVoyage} {v.Destination} {v.Prix}");
	}

	Console.WriteLine("Requête sur les données chargées en mémoire :");
	var resultat = context.Voyages.Local.Where(v => v.Prix < 2000).ToList();
	foreach (Voyage v in resultat)
	{
		Console.WriteLine($"> {v.CodeVoyage} {v.Destination} {v.Prix}");
	} 
}

static void MethodeFind()
{
    using var context = new VoyagesDbContext();
    	
	context.Clients.Where(v => v.Ville == "Reims").Load();

	// Acccès base, même si l'entité a déjà été chargée 
	Client? client = context.Clients.SingleOrDefault(c => c.ClientId== 1);

	if (client != null)
	{
		Console.WriteLine("Client trouvé : " + client.Nom);
	}
   
}

static void ChargementReferences()
{
    using var context = new VoyagesDbContext();
    List<Voyage> voyages = context.Voyages.Where(it => it.CategorieId == 3).ToList();

    foreach (Voyage voyage in voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");

        // La Mt Load est associée à la Pté Collection accessible par le EntityEntry<TEntity> d'une entité
        // Cette collection (CollectionEntry<TEntity, TNav>) représente une Pté de navigation
        context.Entry(voyage).Collection(c => c.Reservations).Load();

        // Idem avec une pté de nav. en réfence. Exemple :
        // context.Entry(voyage).Reference(v => v.Categorie).Load();

        foreach (Reservation resa in voyage.Reservations)
        {
            Console.WriteLine("   Code={0}, Prix={1}, Qte={2}", resa.CodeVoyage, resa.PrixUnitaire, resa.Qte);
        }
    }
}

static void LazyLoading()
{
    // Lazy loading avec PN Microsoft.EntityFrameworkCore.Proxies
    // avec  optionsBuilder.UseLazyLoadingProxies();
    // Les ptés de navigation doivent être déclarées avec virtual

    using var context = new VoyagesDbContext();
    List<Voyage> voyages = context.Voyages.Where(it => it.CategorieId == 3).ToList();

    // Activation/désactivation à la demande
    //context.ChangeTracker.LazyLoadingEnabled = false;

    foreach (Voyage voyage in voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");

        foreach (Reservation resa in voyage.Reservations)
        {
            Console.WriteLine("   Code={0}, Prix={1}, Qte={2}", resa.CodeVoyage, resa.PrixUnitaire, resa.Qte);
        }
    }
}

static void EagerLoading()
{
    using var context = new VoyagesDbContext();
    List<Voyage> voyages = context.Voyages
        .Where(it => it.CategorieId == 3)
        .Include(it => it.Reservations)
        .ToList();

    foreach (Voyage voyage in voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");

        foreach (Reservation resa in voyage.Reservations)
        {
            Console.WriteLine("   Code={0}, Prix={1}, Qte={2}", resa.CodeVoyage, resa.PrixUnitaire, resa.Qte);
        }
    }
}

static void EagerLoadingFiltre()
{
    using var context = new VoyagesDbContext();
    // Désactiver l'éventuel LazyLoading
    context.ChangeTracker.LazyLoadingEnabled = false;

    // Filtrage sur les Include (+ Batch, Audit, ...) avec PN Z.EntityFramework.Plus.EFCore
    List<Voyage> voyages = context.Voyages
        .Where(it => it.CategorieId == 3)
        //.IncludeFilter(c => c.Reservations.Where(r => r.Qte >= 5))
        .ToList();

    foreach (Voyage voyage in voyages)
    {
        Console.WriteLine($"{voyage.CodeVoyage} {voyage.Destination}");

        foreach (Reservation resa in voyage.Reservations)
        {
            Console.WriteLine("   Code={0}, Prix={1}, Qte={2}", resa.CodeVoyage, resa.PrixUnitaire, resa.Qte);
        }
    }
}

