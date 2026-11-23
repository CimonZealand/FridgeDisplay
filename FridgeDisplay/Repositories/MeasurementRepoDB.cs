using FridgeAid.Api.Data;
using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public class MeasurementRepoDB : IMeasurementRepository
    {
        private readonly FridgeAidDbContext _context;

        public MeasurementRepoDB(FridgeAidDbContext context)
        {
            _context = context;
        }

        public Measurement AddMeasurement(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            _context.SaveChanges();
            return measurement;
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
