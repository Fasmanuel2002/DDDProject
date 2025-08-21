using Application.Workers.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.GetById
{
    public record GetWorkerByIdQuery(Guid Id) : IRequest<ErrorOr<WorkerResponse>>;
}
