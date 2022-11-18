using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : Controller
    {
        private readonly DatabaseContext _context;
        public PlanController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("/removePlans")]
        public IActionResult RemovePlans()
        {
            _context.TrainingPlans.RemoveRange(_context.TrainingPlans);

            _context.SaveChanges();

            return NoContent();
        }

            [HttpGet("/addPlans")]
        public IActionResult AddPlans()
        {
            TrainingDay td1 = new TrainingDay { Number = 1, DateTime = DateTime.UtcNow };

            

            TrainingPlan tp5KL1 = new TrainingPlan
            {
                Type = "5K",
                Level = 1,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "5K"
            };

            _context.TrainingPlans.Add(tp5KL1);

            TrainingPlan tp5KL2 = new TrainingPlan
            {
                Type = "5K",
                Level = 2,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "5K"
            };

            _context.TrainingPlans.Add(tp5KL2);

            TrainingPlan tp5KL3 = new TrainingPlan
            {
                Type = "5K",
                Level = 3,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "5K"
            };

            _context.TrainingPlans.Add(tp5KL3);

            TrainingPlan tp10KL1 = new TrainingPlan
            {
                Type = "10K",
                Level = 1,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "10K"
            };

            _context.TrainingPlans.Add(tp10KL1);

            TrainingPlan tp10KL2 = new TrainingPlan
            {
                Type = "10K",
                Level = 2,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "10K"
            };

            _context.TrainingPlans.Add(tp10KL2);

            TrainingPlan tp10KL3 = new TrainingPlan
            {
                Type = "10K",
                Level = 3,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "10K"
            };
            _context.TrainingPlans.Add(tp10KL3);

            TrainingPlan tpHALFMARATHONKL1 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 1,
                DurationInWeeks = 15,
                StartDate = DateTime.UtcNow,
                Description = "HALF MARATHON"
            };
            _context.TrainingPlans.Add(tpHALFMARATHONKL1);

            TrainingPlan tpHALFMARATHONKL2 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 2,
                DurationInWeeks = 15,
                StartDate = DateTime.UtcNow,
                Description = "HALF MARATHON"
            };
            _context.TrainingPlans.Add(tpHALFMARATHONKL2);

            TrainingPlan tpHALFMARATHONKL3 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 3,
                DurationInWeeks = 15,
                StartDate = DateTime.UtcNow,
                Description = "HALF MARATHON"
            };
            _context.TrainingPlans.Add(tpHALFMARATHONKL3);

            TrainingPlan tpMARATHONKL1 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 1,
                DurationInWeeks = 18,
                StartDate = DateTime.UtcNow,
                Description = "MARATHON"
            };
            _context.TrainingPlans.Add(tpMARATHONKL1);

            TrainingPlan tpMARATHONKL2 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 2,
                DurationInWeeks = 18,
                StartDate = DateTime.UtcNow,
                Description = "MARATHON"
            };
            _context.TrainingPlans.Add(tpMARATHONKL2);

            TrainingPlan tpMARATHONKL3 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 3,
                DurationInWeeks = 18,
                StartDate = DateTime.UtcNow,
                Description = "MARATHON"
            };
            _context.TrainingPlans.Add(tpMARATHONKL3);

            _context.SaveChanges();

            return NoContent();
        }
    }
}

