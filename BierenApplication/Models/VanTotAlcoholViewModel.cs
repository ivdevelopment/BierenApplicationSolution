using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace BierenApplication.Models
{
    public class VanTotAlcoholViewModel : IValidatableObject
    {
        [Display(Name = "Van alcoholpercentage")]
        [Required(ErrorMessage = "Van alcoholpercentage is verplicht")]
        public float? VanAlcohol { get; set; }
        [Display(Name = "Tot alcoholpercentage")]
        [Required(ErrorMessage = "Tot alcoholpercentage is verplicht")]
        public float? TotAlcohol { get; set; }
        public List<Bier> Bieren { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (VanAlcohol > TotAlcohol)
                validationResults.Add(new ValidationResult("VanAlcohol is groter dan TotAlcohol"));
            return validationResults;
        }
    }
}
