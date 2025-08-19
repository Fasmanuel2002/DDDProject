using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public interface IUnitOfWork
    {
        // Saves the changes made in the unit of work to the underlying data store.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
