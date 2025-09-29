using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using EpmloyeeAdminPortal.Services.Validators;
using Microsoft.EntityFrameworkCore;
using TinyResult;
using TinyResult.Enums;

namespace EpmloyeeAdminPortal.Services;

public class EmployeesService : IEmployeesService
{
    private readonly ApplicationDbContext _context;
    private readonly EmployeeExistsValidator _employeeValidator;

    public EmployeesService(ApplicationDbContext context, EmployeeExistsValidator employeeValidator)
    {
        ArgumentNullException.ThrowIfNull(context);
        this._context = context;
        this._employeeValidator = employeeValidator;
    }
    public async Task<GetAllEmployeeOutput> GetAllEmployeesAsync()
    {
        var employees = await this._context.Employees.Where(e => !e.IsDeleted).ToListAsync();

        return new GetAllEmployeeOutput { Employees = employees };
    }

    public async Task<GetEmployeeByIdOutput> GetEmployeeByIdAsync(GetEmployeeByIdInput input)
    {
        var employee = await this._employeeValidator.GetEmployeeAsync(input.Id);

        return new GetEmployeeByIdOutput { Employee = employee};
    }

    public async Task<Result<bool>> AddEmployeeAsync(AddEmployeeInput input)
    {
        await this._context.Employees.AddAsync(input.Employee);
        var saved = await this._context.SaveChangesAsync();
        return CreateResultFromSave(saved, "Failed to add employee");
    }

    public async Task<Result<bool>> DeleteEmployeeAsync(DeleteEmployeeInput input)
    {
        var employee = await this._employeeValidator.GetEmployeeAsync(input.Id);
        if (employee is null)
        {
            return Result<bool>.Failure(Error.Create(ErrorCode.NotFound, "Employee not found"));
        }

        employee.IsDeleted = true;
        var saved = await this._context.SaveChangesAsync();
        return CreateResultFromSave(saved, "Failed to delete employee");
    }


    public async Task<Result<bool>> UpdateEmployeeAsync(UpdateEmployeeInput input)
    {
        var employee = await this._employeeValidator.GetEmployeeAsync(input.Id);
        if (employee is null)
        {
            return Result<bool>.Failure(Error.Create(ErrorCode.NotFound, "Employee not found"));
        }

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
}
