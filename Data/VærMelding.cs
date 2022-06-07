#nullable disable
using System;
using System.Collections.Generic;

namespace Gruppe11.Data
{
    public partial class VærData
    {
        public int Id { get; set; }
        public DateTime? Dato { get; set; }
        public int? Temperatur { get; set; }
        public string Kommentar { get; set; }
        public string Bruker { get; set; }
    }
}
