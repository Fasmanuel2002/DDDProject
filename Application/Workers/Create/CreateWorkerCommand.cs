using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Create
{
    public record CreateWorkerCommand
        (

        string Name,
        string Lastname,
        string PersonIdentification,
        string EmailAdress,

        //Add Addres as value Object, and we pass all the attributes to make the value object
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode
        ): IRequest<ErrorOr<Unit>>;
    
        


    
}
