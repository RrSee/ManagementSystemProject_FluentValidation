using FluentValidation;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;

namespace ManagementSystem.Application.CQRS.Customers.Validators;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(u => u.Name).NotEmpty().
            WithMessage("Name cannot be emoty null or whitespace").
            MaximumLength(50).WithMessage("Maximum 50 caracter is required");

        RuleFor(u => u.Email).NotEmpty().WithMessage("Email cannot be empty")
            .MaximumLength(50).WithMessage("Maximum 50 caracter is required").
            EmailAddress().WithMessage("Email should be in correct format");
    }
}
