using EpmloyeeAdminPortal.Employees.GetEmployee.Dtos;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.GetEmployee;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

public partial class GetEmployeeByIdSourseMapper
{
    public partial GetEmployeeByIdInput Map(GetEmployeeByIdRequest request);

    public partial Employee Map(EmployeeDto dto);
}
