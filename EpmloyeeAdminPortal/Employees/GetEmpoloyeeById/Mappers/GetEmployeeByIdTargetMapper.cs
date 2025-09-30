using EpmloyeeAdminPortal.Employees.GetEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.GetEmployee;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]

public partial class GetEmployeeByIdTargetMapper
{
    public partial GetEmployeeByIdResponse Map(GetEmployeeByIdOutput output);

    public partial EmployeeDto Map(Employee entity);
}
