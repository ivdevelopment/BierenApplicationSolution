using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int Id { get; set; }
        public string? Naam { get; set; }
        [UIHint("kleuren")]
        public float Alcohol { get; set; }
    }
}
