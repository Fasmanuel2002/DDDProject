using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    // Esta clase expone un método de extensión para registrar en el contenedor de dependencias
    // todos los servicios relacionados con el proyecto Application (MediatR, FluentValidation, etc.)
    // utilizando ApplicationAssemblyReference como marcador de assembly.
    public static class DepencyInjection
    {



        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Asi hemos injectado MediataR 
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            //Con esto ya tenemos injectado esto en las referencias 
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

            return services;
        }
    }
}
