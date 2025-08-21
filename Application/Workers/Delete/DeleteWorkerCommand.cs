using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Delete
{
    public record DeleteWorkerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
