using FluentValidation;

namespace Application.Orders.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(v => v.UserId).NotEmpty();
        RuleFor(v => v.OrderDate).NotEmpty();
        RuleFor(v => v.CustomerName).NotEmpty().MaximumLength(500);
        RuleFor(v => v.Reference).MaximumLength(250);
    }
}