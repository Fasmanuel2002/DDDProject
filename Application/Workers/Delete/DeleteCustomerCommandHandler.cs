using Domain.Primitives;
using Domain.Workers;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Delete
{
    internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteWorkerCommand, ErrorOr<Unit>>
    {

        public readonly IWorkerRepository _workerRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository ?? throw new ArgumentNullException(nameof(workerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteWorkerCommand command, CancellationToken cancellationToken)
        {
            if(await _workerRepository.GetByIdAsync(new WorkerId(command.Id)) is not Worker worker){
                return Error.NotFound("Worker.NotFound", "The Woker with the provide ID was not found");
            }
            _workerRepository.DeleteWorkerAsync(worker);
            _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
