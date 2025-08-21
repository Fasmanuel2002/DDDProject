using Application.Workers.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.GetAll
{
    //O sea este es un query por que como no cambia la base de datos
    public record GetAllWokersQuery() : IRequest<ErrorOr<IReadOnlyList<WorkerResponse>>>;
}
