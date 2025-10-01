using EmployeeAdminPortal.Employees.GetEmployeeById.Dtos;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.GetEmployeeById;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]

public partial class GetEmployeeByIdTargetMapper
{
    public partial GetEmployeeByIdResponse Map(GetEmployeeByIdOutput output);

    public partial EmployeeDto Map(Employee entity);
}
