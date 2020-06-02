using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrainingFoodAnalyser.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values
		[Authorize]
		[HttpGet("getauthentificated")]
		public ActionResult<IEnumerable<string>> GetAuthenticated()
		{
			return new string[] {  User.Identity.Name, User.Identity.IsAuthenticated.ToString() };
		}
	}
}