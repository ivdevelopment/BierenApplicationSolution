using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int Id { get; set; }
        [StringLength(20, ErrorMessage =
        "De naam bevat max. {1} tekens")]
        [Required]
        public string? Naam { get; set; }
        [UIHint("kleuren")]
        [Range(0, 15, ErrorMessage = "Alcoholpercentage moet tussen {1} en {2} liggen.")]
        public float Alcohol { get; set; }
        [DisplayFormat(DataFormatString = "€{0:#,##0.00}")]
        public decimal Prijs { get; set; }
    }
}
