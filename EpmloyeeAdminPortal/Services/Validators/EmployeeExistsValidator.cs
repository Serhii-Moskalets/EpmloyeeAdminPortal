using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Services.Validators;

public class EmployeeExistsValidator(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Employee?> GetEmployeeAsync(Guid employeeId)
    {
        return await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);
    }
}
