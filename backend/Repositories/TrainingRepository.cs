using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using TrainingFoodAnalyser.PagingAndSearch;

namespace TrainingFoodAnalyser.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        protected readonly ApplicationDbContext _context;
        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Training> FindAsync(int id)
        {
            return await _context.Training
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Training> FindByNameAsync(string name)
        {
            return await _context.Training
                .Where(t =>t.Name == name)
                .FirstOrDefaultAsync();
        }
        public async Task<PaginatedList<Training>> ListAsync(ParamsTraining paramsTraining)
        {
            var query = _context.Training.Select(t => t);

            if(!string.IsNullOrEmpty(paramsTraining.Name))
            {
                query = query.Intersect(_context.Training
                    .Select(t => t)
                    .Where(t => t.Name.ToString().ToUpper().Contains(paramsTraining.Name.ToUpper())));
            }

            if (paramsTraining.CaloriesBurnedHourFrom != 0 || paramsTraining.CaloriesBurnedHourTo != double.MaxValue)
            {
                query = query.Intersect(_context.Training
                    .Select(t => t)
                    .Where(obj => (Convert.ToDouble(obj.CaloriesBurnedHour) >= paramsTraining.CaloriesBurnedHourFrom
                            && Convert.ToDouble(obj.CaloriesBurnedHour) <= paramsTraining.CaloriesBurnedHourTo)));
            }

            query = query
                .OrderBy(paramsTraining.PropertySort, paramsTraining.SortDirection);

            int totalCount = await query.CountAsync();
            
            query = query
                .Paging(paramsTraining.Page, paramsTraining.PageSize);

            return new PaginatedList<Training>(await query.ToListAsync(), totalCount, paramsTraining.Page , paramsTraining.PageSize);

        }
        public async Task<Training> SaveAsync(Training training)
        {
            Training tr = await FindByNameAsync(training.Name);

            if(tr==null)
            {
                await _context.Training.AddAsync(training);
                
                return training;
            }
            return null;

        }
        public async Task<Training> UpdateAsync(int id, Training training)
        {

            try
            {
                Training trainingOld = await FindAsync(id);
                trainingOld.Name = training.Name;
                trainingOld.CaloriesBurnedHour = training.CaloriesBurnedHour;

                return trainingOld;
            }
            catch(Exception e)
            {
                Console.WriteLine("Updating error for training. " + e.Message);
                return null;
            }
        }
        public async Task<Training> DeleteAsync(int id)
        {
            try
            {
                Training training = await FindAsync(id);
                _context.Training.Remove(training);
                return training;
            }
            catch(Exception e)
            {
                Console.WriteLine("Deletnig error for training. " + e.Message);
                return null;
            }
        }

    }
}