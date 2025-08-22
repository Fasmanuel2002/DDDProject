using Application;
using Domain.Primitives;
using Infrastructure;
using Infrastructure.Persistence;
using Web.API;
using Web.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();