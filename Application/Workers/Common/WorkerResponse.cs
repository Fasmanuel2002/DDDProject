using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Common
{
    //este es el DTO
    public record WorkerResponse(
        string FullName,
        string PersonIdentification, 
        string EmailAddres,
        AddressResponse Address,
        bool Active);

    public record AddressResponse(
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode
        );     
    
}

