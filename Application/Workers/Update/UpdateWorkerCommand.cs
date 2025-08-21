using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Update
{
    public record UpdateWorkerCommand(
        Guid Id,
        string Name,
        string LastName,
        string PersonIdentification,
        string EmailAdress,


        //Address 
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode,
        bool Activate) : IRequest<ErrorOr<Unit>>;
    
}
