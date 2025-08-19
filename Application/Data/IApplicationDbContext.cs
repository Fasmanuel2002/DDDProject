using Domain.Workers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    internal interface IApplicationDbContext
    {
        DbSet<Worker> Workers { get; set; }

        Task<int> SavesChangesAsync(CancellationToken cancellationToken = default);
    }
}
