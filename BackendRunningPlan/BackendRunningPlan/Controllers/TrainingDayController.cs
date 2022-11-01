using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : Controller
    {
        private readonly DatabaseContext _context;
        public TrainingDayController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<TrainingDay>>> GetTrainingDays()
        {
            return await _context.TrainingDays.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDay>> GetTrainingDay(int id)
        {
            var trainingDay = await _context.TrainingDays.FindAsync(id);

            if (trainingDay == null)
            {
                return NotFound();
            }

            return trainingDay;
        }

        [HttpPost]
        public async Task<ActionResult<TrainingDay>> Post([FromBody] TrainingDay trainingDay)
        {
            var newTrainingDay = new TrainingDay
            {
                Number = trainingDay.Number,
                DateTime = trainingDay.DateTime
            };

            _context.TrainingDays.Add(newTrainingDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrainingDay),
                new { id = newTrainingDay.Id },
                newTrainingDay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingDay(int id, [FromBody] TrainingDay TrainingDayChanged)
        {
            if (id != TrainingDayChanged.Id)
            {
                return BadRequest();
            }

            var trainingDay = await _context.TrainingDays.FindAsync(id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            trainingDay.Number = TrainingDayChanged.Number;
            trainingDay.DateTime = TrainingDayChanged.DateTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TrainingDayExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingDay(int id)
        {
            var trainingDay = await _context.TrainingDays.FindAsync(id);

            if (trainingDay == null)
            {
                return NotFound();
            }

            _context.TrainingDays.Remove(trainingDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingDayExists(int id)
        {
            return _context.TrainingDays.Any(e => e.Id == id);
        }

    }
}
