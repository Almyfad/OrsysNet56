using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitBase
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public decimal Prix { get; set; }
    }

    public class Promotion : Article
    {
        public DateTime debut { get; set; }
        public DateTime fin { get; set; }
    }
}
