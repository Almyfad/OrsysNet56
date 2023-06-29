using System.ComponentModel.DataAnnotations;
// Pour les attributs Table et Column :
using System.ComponentModel.DataAnnotations.Schema;

namespace Modele
{
    //[Table("TableArticles")]
    public class Article
    {
        public int ArticleId { get; set; }
        [Required, StringLength(50)]
        public string Designation { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int CategorieId { get; set; }
        public virtual  Categorie Categorie { get; set; }
        public decimal Prix { get; set; }
        [Column("Promo")]
        public bool Promotion { get; set; }
    }
}
