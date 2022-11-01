using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public TrainingController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Training>>> GetTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        [HttpPost]
        public async Task<ActionResult<Training>> Post([FromBody] Training training)
        {
            var newTraining = new Training
            {
                Name = training.Name,
                Description = training.Description,
                Note = training.Note,
            };

            _context.Trainings.Add(newTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTraining),
                new { id = newTraining.Id },
                newTraining);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(int id,[FromBody] Training TrainingChanged)
        {
            if (id != TrainingChanged.Id)
            {
                return BadRequest();
            }

            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            training.Name = TrainingChanged.Name;
            training.Description = TrainingChanged.Description;
            training.Note = TrainingChanged.Note;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TrainingExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = await _context.Trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.Id == id);
        }
    }
}
