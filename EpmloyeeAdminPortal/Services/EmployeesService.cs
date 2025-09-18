using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Microsoft.EntityFrameworkCore;
using TinyResult;
using TinyResult.Enums;

namespace EpmloyeeAdminPortal.Services;

public class EmployeesService : IEmployeesService
{
    private readonly ApplicationDbContext _context;

    public EmployeesService(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this._context = context;
    }
    public async Task<GetAllEmployeeOutput> GetAllEmployeesAsync()
    {
        var employees = await this._context.Employees.Where(e => !e.IsDeleted).ToListAsync();

        return new GetAllEmployeeOutput() { Employees = employees };
    }

    public async Task<GetEmployeeByIdOutput> GetEmployeeByIdAsync(GetEmployeeByIdInput input)
    {
        Guid employeeId = input.Id;
        Employee? employee = await this._context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && !x.IsDeleted);

        if (employee is null)
        {
            return new GetEmployeeByIdOutput { Employee = null };
        }

        return new GetEmployeeByIdOutput() { Employee = employee };
    }

    public async Task<Result<bool>> AddEmployeeAsync(AddEmployeeInput input)
    {
        Employee employee = input.Employee;

        await this._context.Employees.AddAsync(employee);
        var saved = await this._context.SaveChangesAsync();

        return CreateResultFromSave(saved, "Failed to add employee");
    }

    public async Task<Result<bool>> DeleteEmployeeAsync(DeleteEmployeeInput input)
    {
        Guid employeeId = input.Id;
        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);

        var check = CheckEmployeeExists(employee, "delete");
        if (!check.IsSuccess) return Result<bool>.Failure(check.Error!);

        employee!.IsDeleted = true;
        var saved = await this._context.SaveChangesAsync();

        return CreateResultFromSave(saved, "Failed to delete employee");
    }


    public async Task<Result<bool>> UpdateEmployeeAsync(UpdateEmployeeInput input)
    {
        var employee = await this._context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == input.Id);

        var check = CheckEmployeeExists(employee, "update");
        if (!check.IsSuccess) return Result<bool>.Failure(check.Error!);

        employee!.Name = input.Employee.Name;
        employee.Email = input.Employee.Email;
        employee.Phone = input.Employee.Phone;
        employee.Salary = input.Employee.Salary;

        var saved = await this._context.SaveChangesAsync();

        return CreateResultFromSave(saved, "Failed to update employee");
    }

    private static Result<bool> CreateResultFromSave(int saved, string errorMessage)
    {
        return saved > 0
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(Error.Create(ErrorCode.DatabaseError, errorMessage));
    }

    private static Result<Employee> CheckEmployeeExists(Employee? employee, string action)
    {
        return employee is not null
            ? Result<Employee>.Success(employee)
            : Result<Employee>.Failure(Error.Create(ErrorCode.NotFound, $"Employee not found for {action}"));
    }
}
