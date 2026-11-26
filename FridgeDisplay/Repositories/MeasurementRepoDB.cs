using FridgeAid.Api.Data;
using FridgeDisplay.Models;

namespace FridgeDisplay.Repositories
{
    public class MeasurementRepoDB : IMeasurementRepo
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

        public Measurement? GetLatest()
        {
            return _context.Measurements
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();
        }
    }
}