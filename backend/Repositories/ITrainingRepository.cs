using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.PagingAndSearch;

namespace TrainingFoodAnalyser.Repositories
{
    public interface ITrainingRepository
    {
        Task<Training> FindAsync(int id);
        Task<Training> FindByNameAsync(string name);
        Task<PaginatedList<Training>> ListAsync(ParamsTraining paramsTraining);
        Task<Training> SaveAsync(Training training);
        Task<Training> UpdateAsync(int id, Training training);
        Task<Training> DeleteAsync(int id);

    }
}