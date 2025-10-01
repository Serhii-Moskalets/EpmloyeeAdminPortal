using EmployeeAdminPortal.Employees.GetEmployeeById.Dtos;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.GetEmployeeById;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

public partial class GetEmployeeByIdSourseMapper
{
    public partial GetEmployeeByIdInput Map(GetEmployeeByIdRequest request);

    public partial Employee Map(EmployeeDto dto);
}
