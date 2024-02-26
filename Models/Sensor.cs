using System.ComponentModel.DataAnnotations;

namespace AquaCare_Web_App.Models
{
    public class Sensor
    {
        [Key]
        public required string Model { get; set; }
        public DateTime Timestamp {  get; set; }
        public decimal Ph {  get; set; }
        public decimal Temperature { get; set; }
        public decimal SunlightIntensity { get; set; }
        public decimal Salinity { get; set; }
        public decimal Turbidity { get; set; }

    }
}
