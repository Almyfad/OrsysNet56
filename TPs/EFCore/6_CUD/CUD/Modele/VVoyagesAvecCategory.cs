using System;
using System.Collections.Generic;

namespace CUD.Modele
{
    public partial class VVoyagesAvecCategory
    {
        public string CodeVoyage { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public bool Promotion { get; set; }
        public string? LibelleCategorie { get; set; }
    }
}
