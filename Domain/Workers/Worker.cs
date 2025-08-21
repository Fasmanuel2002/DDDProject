using Domain.Primitives;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workers
{
    //La clase sellada se da debido no necesito que esta clase tenga una  modificiacion externa(100 % encapsulada) 
    public sealed class Worker : AggregateRoot //Heredamos todos las funcionnes de nuestra clase AggregateRoot
    {
        public Worker(WorkerId id, string name, string lastName, PersonIdentification personIdentification,EmailAdress emailAdress,Address address, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            PersonIdentification = personIdentification;
            EmailAdress = emailAdress;
            Address = address;
            Active = active;
        }

        private Worker() { } //Constructor por defecto para EF Core

        public WorkerId Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string FullName => $"{Name} {LastName}";

        public PersonIdentification PersonIdentification { get; private set; }

        public EmailAdress EmailAdress { get; private set; }

        public Address Address { get; private set; }
        public bool Active { get; private set; }
    }
}
