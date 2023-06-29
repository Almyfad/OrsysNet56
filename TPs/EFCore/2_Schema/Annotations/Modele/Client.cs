using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modele
{
    public class Client
    {
        public Client()
        {
            ClientGuid = Guid.NewGuid();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ClientGuid { get; set; }
        public StatutClient StatutClient { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        [StringLength(50)]
        public string Prenom { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int AdresseId  { get; set; }
        public virtual Adresse Adresse { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public override string ToString()
        {
            return $"{Prenom} {Nom} @ {Email}";
        }
    }
}
