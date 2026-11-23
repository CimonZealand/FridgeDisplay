namespace FridgeDisplay.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool DoorClosed { get; set; } = true;
    }
}
