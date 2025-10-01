using EmployeeAdminPortal.Employees.UpdateEmployee.Dtos;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.UpdateEmployee;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

public partial class UpdateEmployeeMapper
{
    public partial UpdateEmployeeInput Map(UpdateEmployeeRequest request);

    public partial Employee Map(EmployeeDto dto);
}
