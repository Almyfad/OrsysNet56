using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modele
{
    // TPH / défaut.
    // Pour TPT :
    //[Table("Promotions")]
    public class Promotion : Article
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}
