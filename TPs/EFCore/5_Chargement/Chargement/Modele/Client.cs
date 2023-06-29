using System;
using System.Collections.Generic;

namespace Chargement.Modele
{
    public partial class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int ClientId { get; set; }
        public string? Civilite { get; set; }
        public string Nom { get; set; } = null!;
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public byte[]? TimeStamp { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
