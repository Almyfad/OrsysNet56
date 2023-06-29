using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CUD.Modele
{
    [MetadataType(typeof(VoyageMetadata))] // Ignoré en EF Core
    public partial class Voyage : IValidatableObject
    {
        // Validation au niveau de l'entité, par l'interface IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategorieId != 1 && Prix < 500)
            {
                yield return new ValidationResult(
                    "Le prix doit être supérieur à 500 pour cette catégorie d'article",
                    // Associer l'erreur aux Ptés 
                    new[] { "CategorieId", "Prix" });
            }
        }
    }

    // Validations au niveau des ptés, par des attributs DataAnnotations 
    // Ok sur l'entité, mais pas en MetadataType
    public class VoyageMetadata
    {
        [Required]
        [Range(1, 4, ErrorMessage = "La valeur {0} doit être comprise entre {1} et {2}.")]
        public int CategorieId { get; set; }

        [Required(ErrorMessage = "Destination obligatoire")]
        public string Destination { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "La valeur {0} doit être comprise entre à {1} et {2}.")]
        public decimal Prix { get; set; }
    }
}
