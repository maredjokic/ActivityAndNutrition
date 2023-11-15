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

        [HttpGet("/getPlan")]
        public TrainingPlan AddPlan()
        {
            Training tr1 = new Training { Name = "EasyRunning", Description = "20 min low level running" };

            Training tr2 = new Training { Name = "MediumRunning", Description = "30 min low level running" };

            List<Training> trl1 = new List<Training>
            {
                tr1,
                tr2
            };
            List<Training> trl2 = new List<Training>
            {
                tr1
            };

            TrainingDay td1 = new TrainingDay { Id = 1, Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                    new Training { Name = "MediumRunning", Description = "30 min low level running" }
                }
            };
            TrainingDay td2 = new TrainingDay { Id = 2, Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                    new Training { Name = "MediumRunning", Description = "30 min low level running" }
                }
            };
            TrainingDay td3 = new TrainingDay { Id = 3, Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                    new Training { Name = "MediumRunning", Description = "30 min low level running" },
                     new Training { Name = "MediumRunning", Description = "30 min low level running" }
                }
            };
            TrainingDay td4 = new TrainingDay {
                Id = 4,
                Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                    new Training { Name = "MediumRunning", Description = "30 min low level running" }
                }
            };
            TrainingDay td5 = new TrainingDay {
                Id = 5,
                Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                    new Training { Name = "MediumRunning", Description = "30 min low level running" }
                }
            };
            TrainingDay td6 = new TrainingDay {
                Id = 6,
                Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td7 = new TrainingDay {
                Id = 7,
                Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td8 = new TrainingDay {
                Id = 8,
                Number = 1, DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td9 = new TrainingDay
            {
                Id = 9,
                Number = 1,
                DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td10 = new TrainingDay
            {
                Id = 10,
                Number = 1,
                DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td11 = new TrainingDay
            {
                Id = 11,
                Number = 1,
                DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td12 = new TrainingDay
            {
                Id = 12,
                Number = 1,
                DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };
            TrainingDay td13 = new TrainingDay
            {
                Id = 13,
                Number = 1,
                DateTime = DateTime.UtcNow,
                Trainings = new List<Training>
                {
                    new Training { Name = "EasyRunning", Description = "20 min low level running" },
                }
            };

            TrainingPlan onePlan = new TrainingPlan
            {
                Type = "5K",
                Level = 1,
                DurationInWeeks = 12,
                StartDate = DateTime.UtcNow,
                Description = "5K",
                TrainingDays = new List<TrainingDay> { td1, td2, td3, td4, td5, td6, td7, td8, td9, td10, td11, td12, td13, td1, td2, td3, td4, td5, td6, td7, td8, td9, td10, td11, td12, td13 }
            };

            return onePlan;
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

