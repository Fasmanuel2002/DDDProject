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

        Task<IEnumerable<Worker>> GetAllWorkersAsync();

        Task AddWorkerAsync(Worker worker);

        Task UpdateWorkerAsync(Worker worker);

        Task DeleteWorkerAsync(WorkerId workerId);
    }
}
