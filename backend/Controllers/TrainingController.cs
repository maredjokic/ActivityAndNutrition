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

	[Route("api/Aktivnosti")]
	[Produces("application/json")]
	[ApiController]
	public class AktivnostiController : ControllerBase
	{	
		private readonly ITrainingService _trainingService;
		public AktivnostiController(ITrainingService trainingService)
		{
			_trainingService = trainingService;
		}

        [HttpGet]
		public async Task<ActionResult<PaginatedList<Training>>> Get([FromQuery] ParamsTraining paramsTraining)
		{
			return Ok(await _trainingService.ListAsync(paramsTraining));
		}


		/// GET: api/Aktivnosti/{id}
    
		[HttpGet("{id}")]
		public async Task<ActionResult<Training>> GetById(int id)
		{
			try
			{

			return Ok(await _trainingService.FindAsync(id));

			}
			catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong.");
            }

		}

	
        [HttpPost]
		public async Task<ActionResult<Training>> Post(Training training)
		{
			try
            {
				return await _trainingService.SaveAsync(training);
			}
			catch(Exception e)
            {
                return NotFound(e.Message);
            }
		}

	
		[HttpPut("{id}")]
		public async Task<ActionResult<Training>> Put(int id, Training training)
		{
			try
            {
                return await _trainingService.UpdateAsync(id, training);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }

		}

        [HttpDelete("{id}")]
		public async Task<ActionResult<Training>> Delete(int id)
		{
			try
            {
                return await _trainingService.DeleteAsync(id);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }

		}


    }
}