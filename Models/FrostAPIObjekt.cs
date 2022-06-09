#nullable disable
namespace Gruppe11.Models
{
    public class Rootobject
    {
        public string SourceId { get; set; }
        public DateTime ReferenceTime { get; set; }
        public Observation[] Observations { get; set; }
    }

    public class Observation
    {
        public string ElementId { get; set; }
        public float Value { get; set; }
        public string Unit { get; set; }
        public Level Level { get; set; }
        public string TimeOffset { get; set; }
        public string TimeResolution { get; set; }
        public int TimeSeriesId { get; set; }
        public string PerformanceCategory { get; set; }
        public string ExposureCategory { get; set; }
        public int QualityCode { get; set; }
    }

    public class Level
    {
        public string LevelType { get; set; }
        public string Unit { get; set; }
        public int Value { get; set; }
    }
}
