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

        public Guid ClientGuid { get; set; }

        public StatutClient StatutClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int AdresseId  { get; set; }
        public virtual Adresse Adresse { get; set; }
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            return $"{Prenom} {Nom} @ {Email}";
        }
    }
}
