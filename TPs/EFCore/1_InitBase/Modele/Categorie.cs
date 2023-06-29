using System.Collections.Generic;

namespace Modele
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string LibelleCategorie { get; set; }

        public List<Article> Articles { get; set; }
    }
}
