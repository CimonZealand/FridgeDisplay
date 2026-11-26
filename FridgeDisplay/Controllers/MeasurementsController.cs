using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeDisplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementRepo _measurementRepository;
        public MeasurementsController(IMeasurementRepo measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        [HttpGet("latest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Measurement> GetLatest()
        {
            var latestMeasurement = _measurementRepository.GetLatest();
            if (latestMeasurement == null)
            {
                return NoContent();
            }
            return Ok(latestMeasurement);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Measurement> Post([FromBody] Measurement value)
        {
            var addedMeasurement = _measurementRepository.AddMeasurement(value);
            return StatusCode(201, addedMeasurement);
        }

    }
}
