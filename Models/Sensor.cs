using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaCare_Web_App.Models
{
    public class Sensor
    {
        [Key]
        public required string Model { get; set; }
        public DateTime Timestamp {  get; set; }
        [Column(TypeName = "decimal(6,4)")]
        public decimal Ph {  get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal Temperature { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal SunlightIntensity { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal Salinity { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal Turbidity { get; set; }

    }
}
