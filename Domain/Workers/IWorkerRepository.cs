using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workers
{
    public interface IWorkerRepository
    {
        Task<Worker?> GetByIdAsync(WorkerId Id);

        Task<List<Worker>> GetAllWorkersAsync();
        

        Task AddWorkerAsync(Worker worker);

        Task UpdateWorkerAsync(Worker worker);

        Task DeleteWorkerAsync(Worker worker);

        Task<bool> ExistsAsync(WorkerId id);
    }
}
