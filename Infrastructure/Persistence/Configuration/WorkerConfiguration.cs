using Domain.ValueObjects;
using Domain.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {

            //Esto mapearaa la entidad de Worker con la tabla Worker en la base de datos(mapea)
            builder.HasKey(worker => worker.Id);

            //Tendra una conversion por que esta fuertemente tipada , esto hace que el ID se cree con fuertemente tipado
            builder.Property(worker => worker.Id).HasConversion(workerId => workerId.value, value => new WorkerId(value));

            //Ahora crearemos las propiedades de la base de datos

            builder.Property(worker => worker.Name).HasMaxLength(50);

            builder.Property(worker => worker.LastName).HasMaxLength(50);

            builder.Ignore(worker => worker.FullName);


            builder.Property(worker => worker.PersonIdentification).HasConversion(personIdentification => personIdentification.Value,
                value => PersonIdentification.Create(value)!).HasMaxLength(9);

            builder.Property(worker => worker.EmailAdress).HasConversion(emailAddress => emailAddress.Value,
                value => EmailAdress.Create(value)!).HasMaxLength(25);

            builder.OwnsOne(worker => worker.Address, addresBuilder =>
            {
                addresBuilder.Property(a => a.Country).HasMaxLength(50);
                addresBuilder.Property(a => a.Line1).HasMaxLength(25);
                addresBuilder.Property(a => a.Line2).HasMaxLength(25).IsRequired(false);
                addresBuilder.Property(a => a.City).HasMaxLength(40);
                addresBuilder.Property(a => a.State).HasMaxLength(40);
                addresBuilder.Property(a => a.ZipCode).HasMaxLength(10);
            });

            builder.Property(worker => worker.Active);
        }
    }
}
