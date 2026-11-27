using FridgeDisplay.Models;
using FridgeDisplay.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FridgeDisplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervalController : ControllerBase
    {
        private readonly IIntervalRepo _intervalRepo;

        public IntervalController(IIntervalRepo intervalRepository)
        {
            _intervalRepo = intervalRepository;
        }

        // GET api/interval – henter de nuværende grænseværdier
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Interval> Get()
        {
            Interval interval = _intervalRepo.GetInterval();
            return Ok(interval);
        }

        // PUT api/interval – køkkenet sætter sine egne grænseværdier
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Interval> Put(Interval interval)
        {
            try
            {
                Interval updated = _intervalRepo.UpdateInterval(interval);
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/interval/reset – tilbage til standardværdierne
        [HttpPost("reset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Interval> Reset()
        {
            Interval interval = _intervalRepo.ResetInterval();
            return Ok(interval);
        }
    }
}