using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modele
{
    public class Categorie
    {
        public Categorie()
        {
            Articles = new List<Article>();
        }

        public int CategorieId { get; set; }
		
		[StringLength(50)]
        public string LibelleCategorie { get; set; }

        public virtual ICollection<Article> Articles { get; }
    }
}
