using System;
using System.Collections.Generic;

namespace Chargement.Modele
{
    public partial class Categorie
    {
        public Categorie()
        {
            Voyages = new HashSet<Voyage>();
        }

        public int CategorieId { get; set; }
        public string? LibelleCategorie { get; set; }

        public virtual ICollection<Voyage> Voyages { get; set; }
    }
}
