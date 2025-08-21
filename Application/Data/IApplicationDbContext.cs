using Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Worker> Workers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
