#nullable disable

namespace Gruppe11.Data
{
    public class Observasjon
    {
        public int Id { get; set; }
        public DateTime? Dato { get; set; }
        public int? Temperatur { get; set; }
        public string Bruker { get; set; }
    }
}
