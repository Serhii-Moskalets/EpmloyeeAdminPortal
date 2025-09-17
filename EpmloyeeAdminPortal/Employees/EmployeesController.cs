using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.DeleteEmployee;
using EpmloyeeAdminPortal.Employees.GetEmployee;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Employees.UpdateEmployee;
using EpmloyeeAdminPortal.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        var request = new GetEmpoloyeeById.Request { EmployeeId = id };
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
        var output = await this._employeeService.AddEmployeeAsync(input);
        var response = new AddEmployeeMapper().Map(output);
        return this.Ok(response);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, UpdateEmployee.Request employeeRequest)
    {
        employeeRequest.EmployeeId = id;
        var input = new UpdateEmployeeMapper().Map(employeeRequest);
        var output = await this._employeeService.UpdateEmployeeAsync(input);

        if (output.Employee is null)
        {
            return this.NotFound();
        }

        var response = new UpdateEmployeeMapper().Map(output);
        return this.Ok(response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var request = new DeleteEmployee.Request { EmployeeId = id };
        var input = new DeleteEmployeeMapper().Map(request);

        var output = await this._employeeService.DeleteEmployeeAsync(input);
        
        return output.Success ? this.Ok(output) : this.NotFound(output);
    }
}
