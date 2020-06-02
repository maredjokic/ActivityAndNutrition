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
    public class FoodRepository : IFoodRepository
    {
        protected readonly ApplicationDbContext _context;
        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Food> FindAsync(int id)
        {
            return await _context.Food
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Food> FindByNameAsync(string name)
        {
            return await _context.Food
                .Where(t =>t.Name == name)
                .FirstOrDefaultAsync();
        }
        public async Task<PaginatedList<Food>> ListAsync(ParamsFood paramsFood)
        {
            var query = _context.Food.Select(t => t);


            if(!string.IsNullOrEmpty(paramsFood.Name))
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(t => t.Name.ToString().ToUpper().Contains(paramsFood.Name.ToUpper())));
            }

            if(!string.IsNullOrEmpty(paramsFood.Type))
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(t => t.Type.ToString().ToUpper().Contains(paramsFood.Type.ToUpper())));

            }

            if (paramsFood.CaloriesFrom != 0 || paramsFood.CaloriesTo != double.MaxValue)
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(obj => (Convert.ToDouble(obj.Calories) >= paramsFood.CaloriesFrom
                            && Convert.ToDouble(obj.Calories) <= paramsFood.CaloriesTo)));
            }

            if (paramsFood.CarbohydratePercentFrom != 0 || paramsFood.CarbohydratePercentTo != double.MaxValue)
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(obj => (Convert.ToDouble(obj.CarbohydratePercent) >= paramsFood.CarbohydratePercentFrom
                            && Convert.ToDouble(obj.CarbohydratePercent) <= paramsFood.CarbohydratePercentTo)));
            }

            if (paramsFood.ProteinPercentFrom != 0 || paramsFood.ProteinPercentTo != double.MaxValue)
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(obj => (Convert.ToDouble(obj.ProteinPercent) >= paramsFood.ProteinPercentFrom
                            && Convert.ToDouble(obj.ProteinPercent) <= paramsFood.ProteinPercentTo)));
            }

            if (paramsFood.FatPercentFrom != 0 || paramsFood.FatPercentTo != double.MaxValue)
            {
                query = query.Intersect(_context.Food
                    .Select(t => t)
                    .Where(obj => (Convert.ToDouble(obj.FatPercent) >= paramsFood.FatPercentFrom
                            && Convert.ToDouble(obj.FatPercent) <= paramsFood.FatPercentTo)));
            }

            query = query
                .OrderBy(paramsFood.PropertySort, paramsFood.SortDirection);

            int totalCount = await query.CountAsync();
            
            query = query
                .Paging(paramsFood.Page, paramsFood.PageSize);


            return new PaginatedList<Food>(await query.ToListAsync(), totalCount,paramsFood.Page ,paramsFood.PageSize);

        }
        public async Task<Food> SaveAsync(Food food)
        {
            Food fd = await FindByNameAsync(food.Name);

            if(fd==null)
            {
                await _context.Food.AddAsync(food);

                return food;
            }
            return null;

        }
        public async Task<Food> UpdateAsync(int id, Food food)
        {
            try
            {
                Food foodOld = await FindAsync(id);
                foodOld.Name = food.Name;
                foodOld.Calories = food.Calories;
                foodOld.CarbohydratePercent = food.CarbohydratePercent;
                foodOld.FatPercent = food.FatPercent;
                foodOld.ProteinPercent = food.ProteinPercent;
                foodOld.Type = food.Type;


                return foodOld;
            }
            catch(Exception e)
            {
                Console.WriteLine("Updating error for food. " + e.Message);
                return null;
            }
        }
        public async Task<Food> DeleteAsync(int id)
        {
            try
            {
                Food food = await FindAsync(id);
                _context.Food.Remove(food);
                
                return food;
            }
            catch(Exception e)
            {
                Console.WriteLine("Deletnig error for training. " + e.Message);
                return null;
            }
        }

    }
}