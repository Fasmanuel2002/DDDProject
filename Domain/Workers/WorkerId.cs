using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workers
{

    //Objeto Tipado que me va a permitir qeu sera el ID de Worker
    public record WorkerId(Guid value);
}
