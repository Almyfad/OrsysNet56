using System.ComponentModel.DataAnnotations;

namespace Modele
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public string Voie { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
}
