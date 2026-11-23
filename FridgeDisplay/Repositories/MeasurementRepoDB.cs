using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public class MeasurementRepoDB : IMeasurementRepository
    {
        private readonly MeasurementDBContext _context;

        public MeasurementRepoDB(MeasurementDBContext context)
        {
            _context = context;
        }

        public Measurement AddMeasurement(Measurement measurement)
        {

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
