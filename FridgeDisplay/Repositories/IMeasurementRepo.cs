using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public interface IMeasurementRepo
    {
        public Measurement AddMeasurement(Measurement measurement);
        public Measurement? GetLatest();
    }
}
