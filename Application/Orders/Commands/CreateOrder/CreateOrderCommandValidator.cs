using Application.Common.Interfaces.Persistance.Repositories;
using FluentValidation;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> 
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.CartItemIds)
            .NotEmpty().WithMessage("Cart item IDs cannot be empty.")
            .Must(ids => ids.All(id => id > 0)).WithMessage("All cart item IDs must be positive integers.");
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");
        RuleFor(x => x.CustomerEmail)
            .NotEmpty().WithMessage("Customer email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(100).WithMessage("Customer email cannot exceed 100 characters.");
        RuleFor(x => x.CustomerPhone)
            .NotEmpty().WithMessage("Customer phone is required.")
            .Matches(@"^\+?[0-9]\d{1,14}$").WithMessage("Invalid phone number format.")
            .MaximumLength(15).WithMessage("Customer phone cannot exceed 15 characters.");
        RuleFor(x => x.CustomerAddress)
            .NotEmpty().WithMessage("Customer address is required.")
            .MaximumLength(200).WithMessage("Customer address cannot exceed 200 characters.");
        RuleFor(x => x.Note)
            .MaximumLength(500).WithMessage("Note cannot exceed 500 characters.");
    }
}
