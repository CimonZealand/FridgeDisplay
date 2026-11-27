namespace FridgeDisplay.Models
{
    public class Interval
    {
        public int Id { get; set; }
        public double MinTemperature { get; set; } = 3.0;
        public double MaxTemperature { get; set; } = 5.0;
        public double MinHumidity { get; set; } = 60.0;
        public double MaxHumidity { get; set; } = 80.0;
        public const double HumidityWarningMargin = 5.0;
    }
}
