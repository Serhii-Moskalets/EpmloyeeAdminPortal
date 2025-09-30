using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.DeleteEmployee;
using EpmloyeeAdminPortal.Employees.GetEmployee;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Employees.UpdateEmployee;
using EpmloyeeAdminPortal.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TinyResult;
using TinyResult.Enums;

namespace EpmloyeeAdminPortal.Employees;

// localhost:xxxx/api/
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService _employeeService;

    public EmployeesController(IEmployeesService employeeService)
    {
        this._employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        var output = await this._employeeService.GetAllEmployeesAsync();
        var response = new GetAllEmployeeMapper().Map(output);
        return this.Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id)
    {
        var request = new GetEmployeeByIdRequest { Id = id };
        var input = new GetEmployeeByIdSourseMapper().Map(request);
        var result = await this._employeeService.GetEmployeeByIdAsync(input);

        if (!result.IsSuccess)
        {
            return this.NotFound(result.Error?.Message);
        }

        var output = result.Value;
        var response = new GetEmployeeByIdTargetMapper().Map(output!);
        return this.Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync(AddEmployeeRequest employeeRequest, [FromServices] IValidator<AddEmployeeRequest> validator)
    {
        var validationRequest = await validator.ValidateAsync(employeeRequest);
        if (!validationRequest.IsValid)
        {
            return this.BadRequest(validationRequest.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var input = new AddEmployeeMapper().Map(employeeRequest);
        var result = await this._employeeService.AddEmployeeAsync(input);

        return result.IsSuccess
            ? this.Ok(new { Message = "Employee added successfully" })
            : result.Error!.Code switch
            {
                ErrorCode.ValidationError => this.BadRequest(new { result.Error.Message }),
                ErrorCode.DatabaseError => this.StatusCode(500, new { result.Error.Message }),
                _ => this.BadRequest(new { result.Error.Message })
            };
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest employeeRequest, [FromServices] IValidator<UpdateEmployeeRequest> validator)
    {
        employeeRequest.Id = id;
        var validationRequest = await validator.ValidateAsync(employeeRequest);

        if (!validationRequest.IsValid)
        {
            return this.BadRequest(validationRequest.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var input = new UpdateEmployeeMapper().Map(employeeRequest);
        var result = await this._employeeService.UpdateEmployeeAsync(input);

        return result.IsSuccess
            ? this.Ok(new { Message = "Employee updated successfully " })
            : result.Error!.Code switch
            {
                ErrorCode.ValidationError => this.BadRequest(new { result.Error.Message }),
                ErrorCode.NotFound => this.NotFound(new { result.Error.Message }),
                ErrorCode.DatabaseError => this.StatusCode(500, new { result.Error.Message }),
                _ => this.BadRequest(new { result.Error.Message })
            };
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var request = new DeleteEmployeeRequest { Id = id };
        var input = new DeleteEmployeeMapper().Map(request);
        var result = await this._employeeService.DeleteEmployeeAsync(input);

        return result.IsSuccess
            ? this.Ok(new { Message = "Employee deleted successfully " })
            : result.Error!.Code switch
            {
                ErrorCode.ValidationError => this.BadRequest(new { result.Error.Message }),
                ErrorCode.NotFound => this.NotFound(new { result.Error.Message }),
                ErrorCode.DatabaseError => this.StatusCode(500, new { result.Error.Message }),
                _ => this.BadRequest(new { result.Error.Message })
            };
    }
}
