using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; // sin punto
using Infrastructure.Persistence;
using Application.Data;
using Domain.Primitives;
using Infrastructure.Persistence.Repositories;
using Domain.Workers; // si ApplicationDbContext está aquí

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        // Separación para agregar más servicios por capas
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            //esta representa la base de datos, es decir, la conexion a la base de datos
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));


            //Esta dependencia hace referencia a DbContext, es decir, la base de datos
            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());


            //Esta dependencia hace referencia a UnitOfWork, es decir, la unidad de trabajo
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());


            //Registramos el repositorio de clientes
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            return services;
        }
    }
}
//La injection de db context, con la cadena de la Database, injectamos el scopped services con el DbContext, y luego inyectamos el IApplicationDbContext y el IUnitOfWork, que es la unidad de trabajo, que es la que nos permite hacer transacciones en la base de datos, y luego inyectamos el repositorio de clientes, que es el que nos permite acceder a los clientes en la base de datos.
//Hacmeos tambien con Unit of work y con el repositorio de clientes, que es el que nos permite acceder a los clientes en la base de datos.