using EmployeeAdminPortal.Employees.GetAllEmployees.Dtos;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.GetAllEmployees;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]

public partial class GetAllEmployeeMapper
{
    public partial GetAllEmployeesResponse Map(GetAllEmployeeOutput output);

    public partial EmployeeDto Map(Employee employee);
}
