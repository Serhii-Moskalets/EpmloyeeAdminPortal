using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.DeleteEmployee;
using EpmloyeeAdminPortal.Employees.GetEmployee;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Employees.UpdateEmployee;
using EpmloyeeAdminPortal.Interfaces.Services;
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
        var request = new GetEmpoloyeeByIdRequest { Id = id };
        var input = new GetEmpoloyeeByIdMapper().Map(request);
        var output = await this._employeeService.GetEmployeeByIdAsync(input);

        if (output.Employee is null)
        {
            return this.NotFound();
        }

        var response = new GetEmpoloyeeByIdMapper().Map(output);
        return this.Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync(AddEmployee.Request employeeRequest)
    {
        var input = new AddEmployeeMapper().Map(employeeRequest);
        var result = await this._employeeService.AddEmployeeAsync(input);

        if (result.IsSuccess)
            return this.Ok(new { Message = "Employee added successfully" });

        return result.Error!.Code switch
        {
            ErrorCode.ValidationError => this.BadRequest(new { Message = result.Error.Message }),
            ErrorCode.DatabaseError => this.StatusCode(500, new { Message = result.Error.Message }),
            _ => this.BadRequest(new { Message = result.Error.Message })
        };
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest employeeRequest)
    {
        employeeRequest.Id = id;
        var input = new UpdateEmployeeMapper().Map(employeeRequest);
        var result = await this._employeeService.UpdateEmployeeAsync(input);

        return result.IsSuccess 
            ? this.Ok(new {Message = "Employee updated successfully" }) 
            : this.NotFound(new { Message = result.Error!.Message });
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var request = new DeleteEmployeeRequest { Id = id };
        var input = new DeleteEmployeeMapper().Map(request);

        var result = await this._employeeService.DeleteEmployeeAsync(input);

        return result.IsSuccess
       ? this.Ok(new { Message = "Employee deleted successfully" })
       : this.NotFound(new { Message = result.Error!.Message });
    }
}
