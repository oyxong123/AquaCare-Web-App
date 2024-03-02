﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AquaCare_Web_App.Models.Dtos
{
    public class SensorDto
    {
        public required string Model { get; set; }
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
    }
}
