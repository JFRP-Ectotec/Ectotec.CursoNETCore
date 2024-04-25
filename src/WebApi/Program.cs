using Application;
using Application.Features.Torneos.Create;
using Application.Features.Torneos.Get;

using Domain.Entities;

using FluentResults;

using Infrastructure;

using MediatR;

using Serilog;


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

    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", () =>
    {
        var forecast =  Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

    app.MapPost("torneo/", async (CreateTorneoRequest request, ISender sender) =>
    {
        Torneo torneo = Torneo.Create(
            request.Nombre,
            request.Liga,
            request.Comentarios ?? string.Empty);

        var command = new CreateTorneoCommand(torneo);
        Result<Guid> result = await sender.Send(command);

        return result.Value;
    })
    .WithName("CreateTorneo")
    .WithOpenApi();

    app.MapGet("torneo/{id}", async (Guid id, ISender sender) => 
    {
        GetTorneoQuery query = new(id);
        Result<GetTorneoResponse> result = await sender.Send(query);

        return result.Value;
    })
    .WithName("GetTorneoWithId")
    .WithOpenApi();

    app.Run();
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
