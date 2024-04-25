using FluentValidation;

namespace Domain.Entities.Validators;

public sealed class PosicionValidator : AbstractValidator<Posicion>
{
    public PosicionValidator()
    {
        RuleFor(p => p.Ganados).GreaterThanOrEqualTo(0)
        ;

        RuleFor(p => p.Perdidos).GreaterThanOrEqualTo(0)
        ;

        RuleFor(p => p.Empates).GreaterThanOrEqualTo(0)
        ;

        RuleFor(p => p.ScoreFavor).GreaterThanOrEqualTo(0)
        ;

        RuleFor(p => p.ScoreContra).GreaterThanOrEqualTo(0)
        ;

        RuleFor(p => p.Puntos).GreaterThanOrEqualTo(0)
        ;
    }
}