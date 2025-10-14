using FluentValidation;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                 .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.")
                               .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
    }
}
