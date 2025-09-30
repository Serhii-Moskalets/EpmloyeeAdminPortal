using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TinyResult;
using TinyResult.Enums;

namespace EpmloyeeAdminPortal.Services;

public class EmployeesService : IEmployeesService
{
    private readonly ApplicationDbContext _context;
    private readonly IValidator<GetEmployeeByIdInput> _getByIdValidator;
    private readonly IValidator<UpdateEmployeeInput> _updateValidator;
    private readonly IValidator<DeleteEmployeeInput> _deleteValidator;

    public EmployeesService(
        ApplicationDbContext context,
        IValidator<GetEmployeeByIdInput> getByIdValidator,
        IValidator<UpdateEmployeeInput> updateValidator,
        IValidator<DeleteEmployeeInput> deleteValidator)
    {
        this._context = context;
        this._getByIdValidator = getByIdValidator;
        this._updateValidator = updateValidator;
        this._deleteValidator = deleteValidator;
    }

    public async Task<GetAllEmployeeOutput> GetAllEmployeesAsync()
    {
        var employees = await this._context.Employees.Where(e => !e.IsDeleted).ToListAsync();

        return new GetAllEmployeeOutput { Employees = employees };
    }

    public async Task<Result<GetEmployeeByIdOutput>> GetEmployeeByIdAsync(GetEmployeeByIdInput input)
    {
        var validationResult = await this._getByIdValidator.ValidateAsync(input);

        if (!validationResult.IsValid)
        {
            return Result<GetEmployeeByIdOutput>.Failure(Error.Create(ErrorCode.ValidationError, validationResult.Errors.First().ErrorMessage));
        }

        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == input.Id && !e.IsDeleted);

        if (employee is null)
        {
            return Result<GetEmployeeByIdOutput>.Failure(Error.Create(ErrorCode.NotFound, "Employee not found"));
        }

        var output = new GetEmployeeByIdOutput { Employee = employee! };

        return Result<GetEmployeeByIdOutput>.Success(output);
    }

    public async Task<Result<bool>> AddEmployeeAsync(AddEmployeeInput input)
    {
        await this._context.Employees.AddAsync(input.Employee);
        var saved = await this._context.SaveChangesAsync();
        return CreateResultFromSave(saved, "Failed to add employee");
    }

    public async Task<Result<bool>> DeleteEmployeeAsync(DeleteEmployeeInput input)
    {
        var validationResult = await this._deleteValidator.ValidateAsync(input);

        if (!validationResult.IsValid)
        {
            return Result<bool>.Failure(Error.Create(ErrorCode.ValidationError, validationResult.Errors.First().ErrorMessage));
        }

        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == input.Id && !e.IsDeleted);

        if (employee is null)
        {
            return Result<bool>.Failure(Error.Create(ErrorCode.NotFound, "Employee not found"));
        }

        employee!.IsDeleted = true;
        var saved = await this._context.SaveChangesAsync();
        return CreateResultFromSave(saved, "Failed to delete employee");
    }

    public async Task<Result<bool>> UpdateEmployeeAsync(UpdateEmployeeInput input)
    {
        var validationResult = await this._updateValidator.ValidateAsync(input);

        if (!validationResult.IsValid)
        {
            return Result<bool>.Failure(Error.Create(ErrorCode.ValidationError, validationResult.Errors.First().ErrorMessage));
        }

        var employee = await this._context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == input.Id && !e.IsDeleted);

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
