using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingFoodAnalyser.Data;


namespace TrainingFoodAnalyser.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

