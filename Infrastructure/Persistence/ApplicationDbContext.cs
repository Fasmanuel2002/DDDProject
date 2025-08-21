using Application.Data;
using Domain.Primitives;
using Domain.Workers;
using MediatR; //Librería para pub/sub de eventos y patrones de CQRS.
using Microsoft.EntityFrameworkCore; //Para usar EF Core, que permite trabajar con bases de datos mediante DbContext y DbSet.

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher; //_publisher: Es una instancia de MediatR para publicar Domain Events.

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; } // DbSet<Worker> representa la tabla Workers en la base de datos.



        //Este método configura cómo se mapean las entidades a las tablas.
        //ApplyConfigurationsFromAssembly aplica todas las configuraciones de entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>().Select(entity => entity.Entity)
                .Where(entity => entity.GetDomainEvents().Any())
                .SelectMany(entity => entity.GetDomainEvents());

            var result  = await base.SaveChangesAsync(cancellationToken);

            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
            return result;
        }
    }
}
