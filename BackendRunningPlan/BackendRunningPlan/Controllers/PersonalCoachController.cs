using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalCoachController : Controller
    {
        private readonly DatabaseContext _context;

        public PersonalCoachController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPersonalCoach")]
        public async Task<ActionResult<List<PersonalCoach>>> GetPersonalCoaches()
        {
            return await _context.PersonalCoaches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalCoach>> GetPersonalCoach(int id)
        {
            var coach = await _context.PersonalCoaches.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return coach;
        }

        [HttpPost]
        public async Task<ActionResult<PersonalCoach>> Post(PersonalCoach personalCoach)
        {
            var personalCoachNew = new PersonalCoach
            {
                Name = personalCoach.Name,
                Username = personalCoach.Username,
                Password = personalCoach.Password
            };

            _context.PersonalCoaches.Add(personalCoachNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPersonalCoach),
                new { id = personalCoachNew.Id },
                personalCoach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(int id, PersonalCoach personalCoachChanged)
        {
            if (id != personalCoachChanged.Id)
            {
                return BadRequest();
            }

            var personalCoach = await _context.PersonalCoaches.FindAsync(id);
            if (personalCoach == null)
            {
                return NotFound();
            }

            personalCoach.Name = personalCoachChanged.Name;
            personalCoach.Username = personalCoachChanged.Username;
            personalCoach.Password = personalCoachChanged.Password;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PersonalCoachExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalCoach(int id)
        {
            var personalCoach = await _context.PersonalCoaches.FindAsync(id);

            if (personalCoach == null)
            {
                return NotFound();
            }

            _context.PersonalCoaches.Remove(personalCoach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalCoachExists(int id)
        {
            return _context.PersonalCoaches.Any(e => e.Id == id);
        }
    }
}
