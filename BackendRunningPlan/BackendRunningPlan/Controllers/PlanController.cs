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

        [HttpGet("/addPlans")]
        public IActionResult GetTraining()
        {
            TrainingPlan tp5KL1 = new TrainingPlan
            {
                Type = "5K",
                Level = 1,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "5K"
            };

            TrainingPlan tp5KL2 = new TrainingPlan
            {
                Type = "5K",
                Level = 2,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "5K"
            };

            TrainingPlan tp5KL3 = new TrainingPlan
            {
                Type = "5K",
                Level = 3,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "5K"
            };

            TrainingPlan tp10KL1 = new TrainingPlan
            {
                Type = "10K",
                Level = 1,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "10K"
            };

            TrainingPlan tp10KL2 = new TrainingPlan
            {
                Type = "10K",
                Level = 2,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "10K"
            };

            TrainingPlan tp10KL3 = new TrainingPlan
            {
                Type = "10K",
                Level = 3,
                DurationInWeeks = 12,
                StartDate = DateTime.Today,
                Description = "10K"
            };

            TrainingPlan tpHALFMARATHONKL1 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 1,
                DurationInWeeks = 15,
                StartDate = DateTime.Today,
                Description = "HALF MARATHON"
            };

            TrainingPlan tpHALFMARATHONKL2 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 2,
                DurationInWeeks = 15,
                StartDate = DateTime.Today,
                Description = "HALF MARATHON"
            };

            TrainingPlan tpHALFMARATHONKL3 = new TrainingPlan
            {
                Type = "HALF MARATHON",
                Level = 3,
                DurationInWeeks = 15,
                StartDate = DateTime.Today,
                Description = "HALF MARATHON"
            };

            TrainingPlan tpMARATHONKL1 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 1,
                DurationInWeeks = 18,
                StartDate = DateTime.Today,
                Description = "MARATHON"
            };

            TrainingPlan tpMARATHONKL2 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 2,
                DurationInWeeks = 18,
                StartDate = DateTime.Today,
                Description = "MARATHON"
            };

            TrainingPlan tpMARATHONKL3 = new TrainingPlan
            {
                Type = "MARATHON",
                Level = 3,
                DurationInWeeks = 18,
                StartDate = DateTime.Today,
                Description = "MARATHON"
            };

            return NoContent();
        }
    }
}

