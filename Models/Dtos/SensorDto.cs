using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AquaCare_Web_App.Models.Dtos
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = "";
        public DateTime Timestamp { get; set; }
        [Column(TypeName = "decimal(6,4)")]
        public decimal Ph { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal Temperature { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal SunlightIntensity { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal Salinity { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal Turbidity { get; set; }

        
        [Column(TypeName = "decimal(6,4)")]
        public decimal PhDeviationIndex { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal TemperatureDeviationIndex { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal SunlightIntensityDeviationIndex { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal SalinityDeviationIndex { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal TurbidityDeviationIndex { get; set; }
        public decimal PriorityAbsolute { get; set; }
        public decimal Priority { get; set; }
    }
}
