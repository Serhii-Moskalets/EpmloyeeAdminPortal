using FluentValidation;

namespace EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;

public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdRequest>
{
    public GetEmployeeByIdValidator()
    {
        this.RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}
