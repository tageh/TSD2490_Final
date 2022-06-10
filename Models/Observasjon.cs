namespace Gruppe11.Models
{
    public class Observasjon
    {
        public int Id { get; set; }
        public DateTime? Dato { get; set; } = default(DateTime?);
        public double? Temperatur { get; set; }
    }
}
