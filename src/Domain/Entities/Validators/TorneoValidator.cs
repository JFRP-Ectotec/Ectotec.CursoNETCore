using FluentValidation;

namespace Domain.Entities.Validators;

public sealed class TorneoValidator : AbstractValidator<Torneo>
{
    public TorneoValidator()
    {
        RuleFor(t => t.Id).NotEqual(Guid.Empty)
        ;

        RuleFor(t => t.Nombre).NotNull()
            .NotEmpty()
            .MaximumLength(Torneo.MaxLengthNombre)
        ;

        RuleFor(t => t.Liga).NotNull()
            .NotEmpty()
            .MaximumLength(Torneo.MaxLengthLiga)
        ;

        RuleFor(t => t.Comentarios).MaximumLength(Torneo.MaxLengthComentarios)
        ;

        RuleForEach(t => t.Posiciones).SetValidator(new PosicionValidator());    
    }
}