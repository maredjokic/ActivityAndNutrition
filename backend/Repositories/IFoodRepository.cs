using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.PagingAndSearch;

namespace TrainingFoodAnalyser.Repositories
{
    public interface IFoodRepository
    {
        Task<Food> FindAsync(int id);
        Task<Food> FindByNameAsync(string name);
        Task<PaginatedList<Food>> ListAsync(ParamsFood paramsFood);
        Task<Food> SaveAsync(Food food);
        Task<Food> UpdateAsync(int id, Food food);
        Task<Food> DeleteAsync(int id);

    }
}