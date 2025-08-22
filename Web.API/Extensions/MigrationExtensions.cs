using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Extensions
{

    //Esto sirve para las migracones de
    public static class MigrationExtensions
    {

        //Crea los servicios de migracion
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
//Tenemos qeu descargar "Efcore design" para la api para que pueda hacer las migraciones