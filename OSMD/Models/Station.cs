namespace OSMD.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string PlaceName { get; set; } // название места
        public double GeoLong { get; set; } // долгота - для карт google
        public double GeoLat { get; set; } // широта - для карт google
    }
}
