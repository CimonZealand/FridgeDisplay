namespace FridgeDisplay.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public bool doorClosed { get; set; } = true;
    }
}
