using System;
using System.Collections.Generic;

namespace Chargement.Modele
{
    public partial class Croisiere
    {
        public string CodeVoyage { get; set; } = null!;
        public int NbrJours { get; set; }
        public decimal PrixJour { get; set; }

        public virtual Voyage Voyage { get; set; } = null!;
    }
}
