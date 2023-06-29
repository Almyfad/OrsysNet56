using System.ComponentModel.DataAnnotations;

namespace Modele
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        [StringLength(50)]
        public string Voie { get; set; }
        [StringLength(10)]
        public string CodePostal { get; set; }
        [StringLength(50)]
        public string Ville { get; set; }
    }
}
