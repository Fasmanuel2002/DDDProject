using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class AggregateRoot
    {
        //List of events that have occurred within the aggregate root.
        private readonly List<DomainEvent> _domainEvents = new();


        // Gets the events of this aggregate root.
        public ICollection<DomainEvent> GetDomainEvents() => _domainEvents;


        //Recollects the domains events in the aggregate root.
        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
