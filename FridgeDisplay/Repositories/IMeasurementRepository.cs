namespace FridgeDisplay.Repositories
{
    public interface IMeasurementRepository
    {
        public Measurement AddMeasurement(Measurement measurement);

        public IEnumerable<Measurement> GetAllMeasurements();
        public Measurement? GetMeasurementById(int id);


        

    }
}
