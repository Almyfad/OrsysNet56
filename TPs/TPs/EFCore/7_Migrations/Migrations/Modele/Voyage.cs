using System;
using System.Collections.Generic;

namespace Migrations.Modele
{
    public partial class Voyage
    {
        public Voyage()
        {
            Reservations = new HashSet<Reservation>();
        }

        public string CodeVoyage { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public int CategorieId { get; set; }
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public bool Promotion { get; set; }
		//public bool Disponible { get; set; }
        public virtual Categorie Categorie { get; set; } = null!;
        public virtual Croisiere Croisiere { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
