using FluentValidation;

namespace EpmloyeeAdminPortal.Employees.AddEmployee;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequest>
{
    public AddEmployeeValidator()
    {
        this.RuleFor(x => x.Employee)
            .NotNull().WithMessage("Employee is required");

        this.RuleFor(x => x.Employee.Name)
            .NotEmpty().WithMessage("Name is required")
            .Matches("^[a-zA-Z  ']+$").WithMessage("Name cannot contain numbers or special characters");

        this.RuleFor(x => x.Employee.Email)
            .NotEmpty().EmailAddress().WithMessage("Invalid email format");

        this.RuleFor(x => x.Employee.Phone)
           .Matches(@"^\+?[0-9]{10,15}$")
            .When(x => !string.IsNullOrEmpty(x.Employee.Phone))
            .WithMessage("Invalid phone number format");

        this.RuleFor(x => x.Employee.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0");
    }
}
