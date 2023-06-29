using System.Collections.Generic;

namespace InitBase
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string LibelleCategorie { get; set; }
        public List<Article> Articles { get; set; }
    }
}
