
namespace Web.API
{

    //Haremos esta para separar y dejaar claro con lo que estamos inectando por cada capa  
    public static class DepencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            return services;
        }
    }
}