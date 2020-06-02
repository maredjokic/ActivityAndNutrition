using System.Threading.Tasks;

namespace TrainingFoodAnalyser.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
