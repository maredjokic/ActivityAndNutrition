using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.PagingAndSearch;
using TrainingFoodAnalyser.Services.MainServices;
using TrainingFoodAnalyser.Repositories;

namespace TrainingFoodAnalyser.Controllers
{
	[Route("api/Namirnice")]
	[ApiController]

	public class NamirniceController : ControllerBase
	{	
		private readonly IFoodService _foodService;
		public NamirniceController(IFoodService foodService)
		{
			_foodService = foodService;
		}
        [HttpGet]
		public async Task<ActionResult<PaginatedList<Food>>> Get([FromQuery] ParamsFood paramsFod)
		{
			return Ok(await _foodService.ListAsync(paramsFod));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Food>> GetById(int id)
		{
			return Ok(await _foodService.FindAsync(id));
		}

        [HttpPost]
		public async Task<ActionResult<Food>> Post([FromBody]Food food)
		{
			try
            {
				return await _foodService.SaveAsync(food);
			}
			catch(Exception e)
            {
                return NotFound(e.Message);
            }
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Food>> Put(int id, Food food)
		{
			try
            {
                return await _foodService.UpdateAsync(id, food);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }

		}

        [HttpDelete("{id}")]
		public async Task<ActionResult<Food>> Delete(int id)
		{
			 try
            {
                return await _foodService.DeleteAsync(id);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }

		}
    }
}