using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : Controller
    {
        private readonly DatabaseContext _context;
        public TrainingPlanController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainingPlan>>> GetTrainingPlans()
        {
            return await _context.TrainingPlans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingPlan>> GetTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlans.FindAsync(id);

            if (trainingPlan == null)
            {
                return NotFound();
            }

            return trainingPlan;
        }

        [HttpPost]
        public async Task<ActionResult<TrainingPlan>> Post([FromBody] TrainingPlan trainingPlan)
        {
            var newTrainingPlan = new TrainingPlan
            {
                Type = trainingPlan.Type,
                Level = trainingPlan.Level,
                DurationInWeeks = trainingPlan.DurationInWeeks,
                StartDate = trainingPlan.StartDate,
                Description = trainingPlan.Description
        };

            _context.TrainingPlans.Add(newTrainingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrainingPlan),
                new { id = newTrainingPlan.Id },
                newTrainingPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingDay(int id, [FromBody] TrainingPlan TrainingPlanChanged)
        {
            if (id != TrainingPlanChanged.Id)
            {
                return BadRequest();
            }

            var trainingPlan = await _context.TrainingPlans.FindAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }

            trainingPlan.Type = TrainingPlanChanged.Type;
            trainingPlan.Level = TrainingPlanChanged.Level;
            trainingPlan.DurationInWeeks = TrainingPlanChanged.DurationInWeeks;
            trainingPlan.StartDate = TrainingPlanChanged.StartDate;
            trainingPlan.Description = TrainingPlanChanged.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TrainingPlanExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlans.FindAsync(id);

            if (trainingPlan == null)
            {
                return NotFound();
            }

            _context.TrainingPlans.Remove(trainingPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingPlanExists(int id)
        {
            return _context.TrainingPlans.Any(e => e.Id == id);
        }
    }
}
