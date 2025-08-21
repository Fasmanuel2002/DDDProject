using Domain.Workers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddWorkerAsync(Worker worker) => _context.Workers.Add(worker);


        public async Task DeleteWorkerAsync(Worker worker) => _context.Workers.Remove(worker);


        public Task<bool> ExistsAsync(WorkerId id) => _context.Workers.AnyAsync(worker => worker.Id == id);

        public Task<List<Worker>> GetAllWorkersAsync() => _context.Workers.ToListAsync();

        public Task<Worker?> GetByIdAsync(WorkerId Id) => _context.Workers.FirstOrDefaultAsync(worker => worker.Id == Id);

        public async Task UpdateWorkerAsync(Worker worker) => _context.Workers.Update(worker);
    }
}
