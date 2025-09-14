using Azure.Core;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;

namespace EpmloyeeAdminPortal.Employees.AddEmployee
{
    public static class AddEmployeeMapper
    {
        public static EmployeeInput MapRequestToInput(AddEmployeeRequest request)
        {
            return new EmployeeInput
            {
                Employee = new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Name = request.Employee.Name,
                    Email = request.Employee.Email,
                    Phone = request.Employee.Phone,
                    Salary = request.Employee.Salary,
                }
            };
        }
    }
}
