using Domain.Entities.Validators;
using FluentValidation;

namespace Application.Features.Torneos.Create;

public sealed class CreateTorneoCommandValidator : AbstractValidator<CreateTorneoCommand>
{
    public CreateTorneoCommandValidator()
    {
        RuleFor(x => x.Tournament)
            .NotNull()
            .SetValidator(new TorneoValidator());
    }
}