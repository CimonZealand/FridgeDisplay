using FridgeDisplay.Models;
namespace FridgeDisplay.Repositories
{
    public class MeasurementsRepoList : IMeasurementRepo
    {
        private readonly List<Measurement> _measurements = new List<Measurement>();
        private int _nextId = 1;

        public MeasurementsRepoList(bool includesTestData = false)
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
            // metoden skal tilføje measurement til listen og tilføje et unikt id til measurement, som er auto incrementeret
            measurement.Id = _nextId++;
            _measurements.Add(measurement);
            return measurement;
        }

        public Measurement GetLatest()
        {
            //Metoden skal returnere det seneste measurement i listen. Hvis listen er tom, skal den returnere null.
            if (_measurements.Count == 0)
            {
                return null;
            }
            return _measurements.Last();
        }
    }
}
