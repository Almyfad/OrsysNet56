using System;
using System.Collections.Generic;

namespace Chargement.Modele
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public string CodeVoyage { get; set; } = null!;
        public short Qte { get; set; }
        public DateTime DateReservation { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int ModeReservation { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Voyage CodeVoyageNavigation { get; set; } = null!;
        public virtual ModesReservation ModeReservationNavigation { get; set; } = null!;
    }
}
