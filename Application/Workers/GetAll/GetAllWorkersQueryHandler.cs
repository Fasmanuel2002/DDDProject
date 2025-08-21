using Application.Workers.Common;
using Domain.Primitives;
using Domain.Workers;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.GetAll
{
    internal class GetAllWorkersQueryHandler : IRequestHandler<GetAllWokersQuery, ErrorOr<IReadOnlyList<WorkerResponse>>>
    {
        public readonly IWorkerRepository _workerRepository;
        

        public GetAllWorkersQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository ?? throw new ArgumentNullException(nameof(workerRepository));
            
        }
        public async Task<ErrorOr<IReadOnlyList<WorkerResponse>>> Handle(GetAllWokersQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Worker> workers = await _workerRepository.GetAllWorkersAsync();

            return workers.Select(worker => new WorkerResponse(
                worker.FullName,
                worker.PersonIdentification.Value,
                worker.EmailAdress.Value,
                new AddressResponse(
                worker.Address.Country,
                worker.Address.Line1,
                worker.Address.Line2,
                worker.Address.City,
                worker.Address.State,
                worker.Address.ZipCode
                ), 
                worker.Active)).ToList();

        }
    }
}
