using FridgeDisplay.Models;
namespace FridgeDisplay.Repositories
{
    public class MeasurementsRepoList : IMeasurementRepository
    {
        private readonly List<Measurement> _measurements = new List<Measurement>();
        private int _nextId = 1;

        public MeasurementsRepoList(bool includesTestData = true)
        {
            if (includesTestData == true)
            {
                //Tilføj testdata her
                AddMeasurement(new Measurement { Temperature = 25.5, Humidity = 60, DoorClosed = true });
                AddMeasurement(new Measurement { Temperature = 30.2, Humidity = 55, DoorClosed = false });
                AddMeasurement(new Measurement { Temperature = 28.7, Humidity = 65, DoorClosed = true });
            }

        }

        public Measurement AddMeasurement(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Measurement> GetAllMeasurements()
        {
            throw new NotImplementedException();
        }

        public Measurement? GetMeasurementById(int id)
        {
            throw new NotImplementedException();
        }

        public Measurement RemoveMeasurement(int id)
        {
            throw new NotImplementedException();
        }

        public Measurement? UpdateMeasurement(int id, Measurement updatedMeasurement)
        {
            throw new NotImplementedException();
        }
    }
}
