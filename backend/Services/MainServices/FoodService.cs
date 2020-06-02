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
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FoodService(IUnitOfWork unitOfWork, IFoodRepository foodRepository)
        {
            _unitOfWork = unitOfWork;
            _foodRepository = foodRepository;
        }

        public async Task<Food> FindAsync(int id)
        {
            return await _foodRepository.FindAsync(id);
        }

        public async Task<Food> FindByNameAsync(string name)
        {
            return await _foodRepository.FindByNameAsync(name);
        }

        public async Task<PaginatedList<Food>> ListAsync(ParamsFood paramsFood)
        {
            return await _foodRepository.ListAsync(paramsFood);
        }
        public async Task<Food> SaveAsync(Food food)
        {
            Food result = await _foodRepository.SaveAsync(food);
            await _unitOfWork.CompleteAsync();

            return result;
        }
        public async Task<Food> UpdateAsync(int id, Food food)
        {
            Food result = await _foodRepository.UpdateAsync(id, food);
            await _unitOfWork.CompleteAsync();

            return result;
        }
        public async Task<Food> DeleteAsync(int id)
        {
           Food result = await _foodRepository.DeleteAsync(id);
           await _unitOfWork.CompleteAsync();

           return result;

        }

    }
}