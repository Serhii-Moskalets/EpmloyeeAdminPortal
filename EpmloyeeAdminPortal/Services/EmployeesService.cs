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

    public async Task<AddEmployeeOutput> AddEmployeeAsync(AddEmployeeInput input)
    {
        Employee employee = input.Employee;

        await this._context.Employees.AddAsync(employee);
        await this._context.SaveChangesAsync();

        return new AddEmployeeOutput { Employee = employee };
    }

    public async Task<DeleteEmployeeOutput> DeleteEmployeeAsync(DeleteEmployeeInput input)
    {
        Guid employeeId = input.EmployeeId;
        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);

        if (employee is null)
        {
            return new DeleteEmployeeOutput { Success = false };
        }

        employee.IsDeleted = true;
        await this._context.SaveChangesAsync();

        return new DeleteEmployeeOutput { Success = true };
    }

    public async Task<GetAllEmployeeOutput> GetAllEmployeesAsync()
    {
        var employees = await this._context.Employees.Where(e => !e.IsDeleted).ToListAsync();

        return new GetAllEmployeeOutput() { Employees = employees };
    }

    public async Task<GetEmployeeByIdOutput> GetEmployeeByIdAsync(GetEmployeeByIdInput input)
    {
        Guid employeeId = input.EmployeeId;
        Employee? employee = await this._context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && !x.IsDeleted);

        if (employee is null)
        {
            return new GetEmployeeByIdOutput { Employee = null };
        }

        return new GetEmployeeByIdOutput() { Employee = employee };
    }

    public async Task<UpdateEmployeeOutput> UpdateEmployeeAsync(UpdateEmployeeInput input)
    {
        var employee = await this._context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == input.EmployeeId);

        if (employee is null)
        {
            return new UpdateEmployeeOutput { Employee = null };
        }

        employee.Name = input.Employee.Name;
        employee.Email = input.Employee.Email;
        employee.Phone = input.Employee.Phone;
        employee.Salary = input.Employee.Salary;
        
        await this._context.SaveChangesAsync();
        return new UpdateEmployeeOutput() { Employee = employee };
    }
}
