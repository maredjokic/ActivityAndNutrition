using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DatabaseContext _context;

        public UserController(ILogger<UserController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            var newUser = new User
            {
                Age = user.Age,
                Name = user.Name,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Username = user.Username,
                Password = user.Password
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUser),
                new { id = newUser.Id },
                UserDTO(newUser));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User userChanged)
        {
            if (id != userChanged.Id)
            {
                return BadRequest();
            }

            var userItem = await _context.Users.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            userItem.Age = userChanged.Age;
            userItem.Name = userChanged.Name;
            userItem.Gender = userChanged.Gender;
            userItem.Height = userChanged.Height;
            userItem.Weight = userChanged.Weight;
            userItem.Username = userChanged.Username;
            userItem.Password = userChanged.Password;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UserExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private static User UserDTO(User user) =>
            new User
            {
                Age = user.Age,
                Name = user.Name,
                Gender = user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                Username = user.Username,
                Password = user.Password
            };
    }
}
