namespace AquaCare_Web_App.Models.Dtos
{
    public class SensorPriorityDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = "";
        public string Property { get; set; } = "";
        public decimal PropertyValue { get; set; }
        public decimal PriorityAbsolute { get; set; }
        public decimal Priority { get; set; }
    }
}
