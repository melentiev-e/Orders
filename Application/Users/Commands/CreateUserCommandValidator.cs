using FluentValidation;

namespace Application.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.UserName).NotEmpty().MaximumLength(100);
        RuleFor(v => v.Password).NotEmpty();
        RuleFor(v => v.FullName).NotEmpty().MaximumLength(500);
    }
}