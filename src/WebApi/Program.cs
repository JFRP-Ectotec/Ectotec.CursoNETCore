using Application;
using Application.Features.Torneos.Create;
using Application.Features.Torneos.Get;

using Domain.Entities;

using FluentResults;

using Infrastructure;

using MediatR;

using Serilog;

using Carter;


var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Agregar servicios de Application
    builder.Services.AddApplication()
        .AddInfrastructure(builder.Configuration)
    ;

    // Registrar Carter para manejo de minimal APIs.
    builder.Services.AddCarter();

    // Registrar Servicio de log.
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext())
    ;
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.MapCarter();

    app.Run();
}