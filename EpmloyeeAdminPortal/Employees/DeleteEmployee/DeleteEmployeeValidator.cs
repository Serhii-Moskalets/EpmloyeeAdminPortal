using FluentValidation;

namespace EpmloyeeAdminPortal.Employees.DeleteEmployee;

public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeRequest>
{
    public DeleteEmployeeValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}
