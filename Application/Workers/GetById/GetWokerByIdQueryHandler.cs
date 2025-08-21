using Application.Workers.Common;
using Domain.Workers;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Try

namespace Application.Workers.GetById
{
    internal sealed class GetWokerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, ErrorOr<WorkerResponse>>
    {
        public readonly IWorkerRepository _workerRepository;
        
        public GetWokerByIdQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository ?? throw new ArgumentNullException(nameof(workerRepository));
        }


        public async Task<ErrorOr<WorkerResponse>> Handle(GetWorkerByIdQuery query, CancellationToken cancellationToken)
        {
            if(await _workerRepository.GetByIdAsync(new WorkerId(query.Id)) is not Worker worker)
            {
                return Error.NotFound("Worker.NotFound", "The Worker with the following Id doenst exists");
            }
            return new WorkerResponse(
                worker.FullName,
                worker.PersonIdentification.Value,
                worker.EmailAdress.Value,
                new AddressResponse(worker.Address.Country,
                worker.Address.Line1,
                worker.Address.Line2,
                worker.Address.City,
                worker.Address.State,
                worker.Address.ZipCode),
                worker.Active);
        }
    }
}
