using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using TrainingFoodAnalyser.PagingAndSearch;
using TrainingFoodAnalyser.Repositories;


namespace TrainingFoodAnalyser.Services.MainServices
{
    public class TrainingService : ITrainingService
    {
         private readonly ITrainingRepository _trainingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(IUnitOfWork unitOfWork, ITrainingRepository trainingRepository)
        {
             _unitOfWork = unitOfWork;
            _trainingRepository = trainingRepository;
        }

        public async Task<Training> FindAsync(int id)
        {
            return await _trainingRepository.FindAsync(id);
        }
        public async Task<Training> FindByNameAsync(string name)
        {
            return await _trainingRepository.FindByNameAsync(name);
        }
        public async Task<PaginatedList<Training>> ListAsync(ParamsTraining paramsTraining)
        {
           return await _trainingRepository.ListAsync(paramsTraining);
        }
        public async Task<Training> SaveAsync(Training training)
        {
            Training result = await _trainingRepository.SaveAsync(training);
            await _unitOfWork.CompleteAsync();

            return result;

        }
        public async Task<Training> UpdateAsync(int id, Training training)
        {
            Training result = await _trainingRepository.UpdateAsync(id, training);
            await _unitOfWork.CompleteAsync();

            return result;
        }
        public async Task<Training> DeleteAsync(int id)
        {
          Training result = await _trainingRepository.DeleteAsync(id);
           await _unitOfWork.CompleteAsync();

           return result;
        }

    }
}