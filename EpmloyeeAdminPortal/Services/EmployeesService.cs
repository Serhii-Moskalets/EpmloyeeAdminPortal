using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Microsoft.EntityFrameworkCore;

namespace EpmloyeeAdminPortal.Services;

public class EmployeesService : IEmployeesService
{
    private readonly ApplicationDbContext _context;

    public EmployeesService(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this._context = context;
    }

    public async Task<GetEmployeeOutput> AddEmployeeAsync(EmployeeInput input)
    {
        await this._context.Employees.AddAsync(input.Employee);
        await this._context.SaveChangesAsync();

        return new GetEmployeeOutput { Employee = input.Employee };
    }

    public async Task<GetEmployeeOutput?> DeleteEmployeeAsync(Guid id)
    {
        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == id && !e.IsDeleted);

        if (employee is null)
        {
            return null;
        }

        employee.IsDeleted = true;
        await this._context.SaveChangesAsync();

        return new GetEmployeeOutput { Employee = employee };
    }

    public async Task<List<GetEmployeeOutput>> GetAllEmployeesAsync()
    {
        var employees = await this._context.Employees.Where(e => !e.IsDeleted).ToListAsync();

        return employees.Select(e => new GetEmployeeOutput { Employee = e }).ToList();
    }


    public async Task<GetEmployeeOutput?> GetEmployeeByIdAsync(Guid id)
    {
        Employee? employee = await this._context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == id && !x.IsDeleted);

        if (employee is null)
        {
            return null;
        }

        return new GetEmployeeOutput { Employee = employee };
    }

    public async Task<GetEmployeeOutput?> UpdateEmployeeAsync(Guid id, EmployeeInput input)
    {
        Employee? employee = await this._context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

        if (employee is null)
        {
            return null;
        }

        employee.Name = input.Employee.Name;
        employee.Email = input.Employee.Email;
        employee.Phone = input.Employee.Phone;
        employee.Salary = input.Employee.Salary;
        
        await this._context.SaveChangesAsync();
        return new GetEmployeeOutput { Employee = employee };
    }
}
