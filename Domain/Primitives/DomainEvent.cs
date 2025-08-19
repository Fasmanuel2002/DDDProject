using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    // DomainEvent represents an event that occurs within the domain.
    public record DomainEvent(Guid Id) : INotification;
}
