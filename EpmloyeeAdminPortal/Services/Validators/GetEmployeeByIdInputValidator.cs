using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Models.Inputs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Services.Validators;

public class GetEmployeeByIdInputValidator : AbstractValidator<GetEmployeeByIdInput>
{
    private readonly ApplicationDbContext _context;

    public GetEmployeeByIdInputValidator(ApplicationDbContext context)
    {
        this._context = context;

        this.RuleFor(x => x.Id)
            .MustAsync(this.EmployeeExists)
            .WithMessage("Employee not found");
    }

    private async Task<bool> EmployeeExists(Guid id, CancellationToken ct)
        => await this._context.Employees.AnyAsync(e => e.EmployeeId == id && !e.IsDeleted, ct);
}
