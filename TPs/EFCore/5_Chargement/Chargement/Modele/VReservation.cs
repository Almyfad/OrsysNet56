using System;
using System.Collections.Generic;

namespace Chargement.Modele
{
    public partial class VReservation
    {
        public string CodeVoyage { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string? LibelleCategorie { get; set; }
        public short Qte { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int ClientId { get; set; }
        public string NomClient { get; set; } = null!;
        public string? Prenom { get; set; }
    }
}
