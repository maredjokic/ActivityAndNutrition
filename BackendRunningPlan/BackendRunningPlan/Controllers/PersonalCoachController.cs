using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalCoachController : Controller
    {
        [HttpGet(Name = "GetPersonalCoach")]
        public IEnumerable<PersonalCoach> Get()
        {
            List<PersonalCoach> coachList = new List<PersonalCoach>();

            coachList.Add(new Models.PersonalCoach() { Id = 1, Name = "Marko Djokic", Username = "MarkoDjokic", Password = "mare"});
            coachList.Add(new Models.PersonalCoach() { Id = 2, Name = "Valentina Nejkovic", Username = "ValentinaNejkovic", Password = "mare" });

            return coachList;
        }
    }
}
