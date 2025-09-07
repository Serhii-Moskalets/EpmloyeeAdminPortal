using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Models;
using EpmloyeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EpmloyeeAdminPortal.Controllers
{
    // localhost:xxxx/api/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees() => Ok(this._context.Employess.ToList());

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = this._context.Employess.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            this._context.Employess.Add(employeeEntity);
            this._context.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = this._context.Employess.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            this._context.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = this._context.Employess.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            this._context.Employess.Remove(employee);
            this._context.SaveChanges();

            return Ok(employee);
        }
    }
}
