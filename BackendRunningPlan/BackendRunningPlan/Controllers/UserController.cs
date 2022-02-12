using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            List<User> userList = new List<User>();

            userList.Add(new Models.User(){ Age = 20, Gender = "M", Height = 175, Id = 1, Name = "Marko", Username = "Mare666", Password = "mare", Weight = 73 });
            userList.Add(new Models.User() { Age = 20, Gender = "M", Height = 175, Id = 2, Name = "User", Username = "user12", Password = "mare", Weight = 73 });
            userList.Add(new Models.User() { Age = 20, Gender = "M", Height = 175, Id = 3, Name = "User1", Username = "Userr", Password = "mare", Weight = 73 });

            return userList;
        }
    }
}
