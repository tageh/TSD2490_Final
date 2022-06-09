#nullable disable
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gruppe11.Data
{
    public class Observasjon
    {
        public int Id { get; set; }
        public DateTime? Dato { get; set; }
        public double? Temperatur { get; set; }
        public string Bruker { get; set; }
    }
}
