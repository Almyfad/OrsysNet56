using System;
using System.Collections.Generic;

namespace CUD.Modele
{
    public partial class VEmailsClient
    {
        public int ClientId { get; set; }
        public string? Civilite { get; set; }
        public string Nom { get; set; } = null!;
        public string? Prenom { get; set; }
        public string? Email { get; set; }
    }
}
