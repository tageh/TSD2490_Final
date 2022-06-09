#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Gruppe11.Models
{
    public partial class VærMelding
    {
        public int Id { get; set; }
        [Required]
        public DateTime? Dato { get; set; }
        [Required]
        public int? Temperatur { get; set; }
        public string Kommentar { get; set; }
        public string Bruker { get; set; }
    }
}
