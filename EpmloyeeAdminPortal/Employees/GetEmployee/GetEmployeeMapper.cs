using Azure.Core;
using EpmloyeeAdminPortal.Employees.GetEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;

namespace EpmloyeeAdminPortal.Employees.GetEmployee
{
    public static class GetEmployeeMapper
    {
        public static EmployeeInput MapRequestToInput(GetEmployeeRequest request)
        {
            return new EmployeeInput
            {
                Employee = new Employee
                {
                    Name = request.Employee.Name,
                    Email = request.Employee.Email,
                    Phone = request.Employee.Phone,
                    Salary = request.Employee.Salary,
                }
            };
        }

        public static GetEmployeeResponse MapOutputToResponse(GetEmployeeOutput output)
        {
            if(output.Employee is null)
            {
                throw new ArgumentException("Employee cannot be null", nameof(output));
            }

            return new GetEmployeeResponse
            {
                Employee = new GetEmployeeDto
                {
                    Name = output.Employee.Name,
                    Email = output.Employee.Email,
                    Phone = output.Employee.Phone,
                    Salary = output.Employee.Salary,
                }
            };
        }

        public static List<GetEmployeeResponse> MapOutputListToResponseList(List<GetEmployeeOutput> employees)
        {
            return employees.Select(e => MapOutputToResponse(e)).ToList();
        }
    }
}
