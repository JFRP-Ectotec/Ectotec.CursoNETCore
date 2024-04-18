using FluentValidation;

namespace Application.Features.Torneos.Get;

/// <summary>
/// Validador de una petición para obtener un escenario deportivo.
/// </summary>
public sealed class GetTorneoQueryValidator : AbstractValidator<GetTorneoQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTorneoQueryValidator"/> class.
    /// </summary>
    public GetTorneoQueryValidator()
    {
        RuleFor(e => e.Id).NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty)
        ;
    }
}