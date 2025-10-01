using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Inputs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Services.Validators;

public class DeleteEmployeeInputValidator : AbstractValidator<DeleteEmployeeInput>
{
    private readonly ApplicationDbContext _context;

    public DeleteEmployeeInputValidator(ApplicationDbContext context)
    {
        this._context = context;

        this.RuleFor(x => x.Id)
            .MustAsync(this.EmployeeExists)
            .WithMessage("Employee not found");
    }

    private async Task<bool> EmployeeExists(Guid id, CancellationToken ct)
        => await this._context.Employees.AnyAsync(e => e.EmployeeId == id && !e.IsDeleted, ct);
}
