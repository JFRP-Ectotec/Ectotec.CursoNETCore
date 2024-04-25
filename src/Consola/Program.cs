// See https://aka.ms/new-console-template for more information
using Domain.Entities;
using Domain.Entities.Validators;
using Domain.Errors;
using Dumpify;

Torneo torneo = Torneo.Create("2023", "WBC", "World Baseball Classic");

// torneo.Dump();

// Console.WriteLine($"{torneo.Nombre} es {torneo.Comentarios}");

torneo.AddPosicion("WBC", "2023", "Temp. Regular", "Grupo C", "MEX", 3, 1, 0);
// torneo.AddPosicion("WBC", "2023", "Temp. Regular", "Grupo C", "USA", 3, 1, 0, 26, 16);

// torneo.Dump("Ya con posiciones");

// torneo.Posiciones.ToList().ForEach(
//     p =>
//     {
//         Console.WriteLine($"{p.Id.Club} tuvo {p.ScoreFavor} carreras y recibió {p.ScoreContra}");
//     }
// );

Torneo torneo2 = Torneo.Create("FIFA WC",
"Copa Mundial de FIFA Varonil", 
"Puro partido amañanado");
torneo2.Dump();

TorneoValidator validator = new();
// var validacion = await validator.ValidateAsync(torneo2);
FluentValidation.Results.ValidationResult validacion = validator.Validate(torneo2);
if (!validacion.IsValid)
{
    validacion.ToDictionary().Dump();
}

string mensajeError = Errors.ErrorTorneo.Existente("2023", "maFIFA").Description;

string mensajeError2 = DateTime.UtcNow.ToShortDateString();