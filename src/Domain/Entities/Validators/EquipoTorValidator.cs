using FluentValidation;

namespace Domain.Entities.Validators;

public sealed class EquipoTorValidator : AbstractValidator<EquipoTor>
{
    public EquipoTorValidator()
    {
        RuleFor(e => e.Liga).NotNull()
            .NotEmpty()
            .MaximumLength(Torneo.MaxLengthLiga)
        ;

        RuleFor(e => e.Torneo).NotNull()
            .NotEmpty()
            .MaximumLength(Torneo.MaxLengthNombre)
        ;

        RuleFor(e => e.Etapa).NotNull()
            .NotEmpty()
            .MaximumLength(50)
        ;

        RuleFor(e => e.Grupo).NotNull()
            .NotEmpty()
            .MaximumLength(30)
        ;

        RuleFor(e => e.Club).NotNull()
            .NotEmpty()
            .MaximumLength(50)
        ;
    }
}