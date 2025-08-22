using Domain.Primitives;
using Domain.ValueObjects;
using Domain.Workers;
using ErrorOr;
using MediatR;

namespace Application.Workers.Create
{
    internal sealed class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, ErrorOr<Unit>>
    {

        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkerCommandHandler(IWorkerRepository wokerRepository,  IUnitOfWork unitOfWork)
        {
            
            _workerRepository = wokerRepository ?? throw new ArgumentNullException(nameof(wokerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        } 
        public async Task<ErrorOr<Unit>> Handle(CreateWorkerCommand command, CancellationToken cancellationToken)
        {
            //Creamos reglas de validacion

            if(EmailAdress.Create(command.EmailAdress) is not EmailAdress emailAdress)
            {
                return Error.Validation("Worker.PhoneNumber", "Phone Number is not valid format.");
            }

            if(PersonIdentification.Create(command.PersonIdentification) is not PersonIdentification personIdentification)
            {
                return Error.Validation("Worker.PersonIdentification", "The Person Identification is not in a valid format");
            }

            if(Address.Create(command.Country, command.Line1, command.Line2, command.City, 
                command.State, command.ZipCode) is not Address address) 
            {
                return Error.Validation("Worker.Addres", "Address, is not in a valid format.");
            }
            var worker = new Worker(
                new WorkerId(Guid.NewGuid()),
                command.Name,
                command.Lastname,
                personIdentification,
                emailAdress,
                address,
                true
                );

            await _workerRepository.AddWorkerAsync(worker);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
