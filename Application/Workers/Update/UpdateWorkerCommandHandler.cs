using Domain.Primitives;
using Domain.ValueObjects;
using Domain.Workers;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Update
{
    internal sealed class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, ErrorOr<Unit>>
    {
        public readonly IWorkerRepository _workerRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UpdateWorkerCommandHandler(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository ?? throw new ArgumentNullException(nameof(workerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateWorkerCommand command, CancellationToken cancellationToken)
        {
            //Applicamos validacion
            if (!await _workerRepository.ExistsAsync(new WorkerId(command.Id)))
            {
                return Error.NotFound("Worker.NotFound", "The worker with the provide Id is not found");
            }

            if(PersonIdentification.Create(command.PersonIdentification) is not PersonIdentification personIdentification)
            {
                return Error.Validation("Worker.PersonIdentification", "PersonIdentification has not valid format");
            }

            if (EmailAdress.Create(command.EmailAdress) is not EmailAdress emailAdress) 
            {
                return Error.Validation("Worker.EmailAdress", "EmailAdress not found");
            }

            if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
                   command.State, command.ZipCode) is not Address address)
            {
                return Error.Validation("Customer.Address", "Address is not valid.");
            }

            Worker worker = Worker.UpdateWorker(
                command.Id,
                command.Name,
                command.LastName,
                personIdentification,
                emailAdress,
                address,
                command.Activate
                );

            _workerRepository.UpdateWorkerAsync(worker);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
