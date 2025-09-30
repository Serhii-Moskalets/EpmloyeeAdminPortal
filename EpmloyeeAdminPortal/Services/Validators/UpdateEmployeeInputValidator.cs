using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Models.Inputs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Services.Validators;

public class UpdateEmployeeInputValidator : AbstractValidator<UpdateEmployeeInput>
{
    private readonly ApplicationDbContext _context;

    public UpdateEmployeeInputValidator(ApplicationDbContext context)
    {
        this._context = context;

        this.RuleFor(x => x.Id)
            .MustAsync(this.EmployeeExists)
            .WithMessage("Employee not found");
    }

    private async Task<bool> EmployeeExists(Guid id, CancellationToken ct)
        => await this._context.Employees.AnyAsync(e => e.EmployeeId == id && !e.IsDeleted, ct);
}
