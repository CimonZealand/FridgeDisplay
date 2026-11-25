using FridgeAid.Api.Data;
using FridgeDisplay.Models;
using System.Diagnostics.Metrics;

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
            return _context.Measurements.ToList();
        }

        public Measurement? GetLatest() 
        {
            if (!_context.Measurements.Any())
            {
                return null;
            }
            return _context.Measurements
                .OrderByDescending(m => m.Id) // via order by decending finder den seneste measurement, da id er auto incrementeret.
                .First();
        }

        public Measurement? GetMeasurementById(int id)
        {
            return _context.Measurements.FirstOrDefault(p => p.Id == id);
        }

        public Measurement RemoveMeasurement(int id)
        {
            throw new NotImplementedException();
        }

        public Measurement? UpdateMeasurement(int id, Measurement updatedMeasurement)
        {
            Measurement? measurement = GetMeasurementById(id);
            if (measurement == null)
            {
                return null;
            }
            _context.Measurements.Remove(measurement);
            _context.SaveChanges();
            return measurement;
        }
    }
}
