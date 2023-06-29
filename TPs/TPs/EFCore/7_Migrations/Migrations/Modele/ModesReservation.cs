using System;
using System.Collections.Generic;

namespace Migrations.Modele
{
    public partial class ModesReservation
    {
        public ModesReservation()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int ModeReservationId { get; set; }
        public string? LibelleModeReservation { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
