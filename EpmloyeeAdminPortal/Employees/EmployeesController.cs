using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.GetEmployee;
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
        var employees = await this._employeeService.GetAllEmployeesAsync();

        var correctEmployees = GetEmployeeMapper.MapOutputListToResponseList(employees);

        return this.Ok(correctEmployees);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await this._employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return this.NotFound();
        }

        var correctEmployee = GetEmployeeMapper.MapOutputToResponse(employee);
        return this.Ok(correctEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync(AddEmployeeRequest employeeRequest)
    {
        var employee = AddEmployeeMapper.MapRequestToInput(employeeRequest);
        await this._employeeService.AddEmployeeAsync(employee);
        return this.Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployeeAsync(Guid id, GetEmployeeRequest employeeRequest)
    {
        var employeeInput = GetEmployeeMapper.MapRequestToInput(employeeRequest);
        var updatedEmployee = await this._employeeService.UpdateEmployeeAsync(id, employeeInput);

        if (updatedEmployee == null)
        {
            return this.NotFound();
        }

        var correctEmployee = GetEmployeeMapper.MapOutputToResponse(updatedEmployee);
        return this.Ok(correctEmployee);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var deletedEmployee = await this._employeeService.DeleteEmployeeAsync(id);
        if (deletedEmployee == null)
        {
            return this.NotFound();
        }

        var correctEmployee = GetEmployeeMapper.MapOutputToResponse(deletedEmployee);
        return this.Ok(correctEmployee);
    }
}
