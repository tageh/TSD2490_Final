using System.ComponentModel.DataAnnotations;

namespace Gruppe11.Models
{
    public class DatoFilter
    {
        [Required]
        public DateTime? FraDato { get; set; }
        [Required]
        public DateTime? TilDato { get; set; }
    }
}
