using FridgeDisplay.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FridgeDisplay.Models;

namespace FridgeDisplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementRepository _measurementRepository;
        public MeasurementsController(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        [HttpGet("latest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Measurement> GetLatest() { 
            var latestMeasurement = _measurementRepository.GetLatest();
            if (latestMeasurement == null)
            {
                return NoContent();
            }
            return Ok(latestMeasurement);}
    }
}
