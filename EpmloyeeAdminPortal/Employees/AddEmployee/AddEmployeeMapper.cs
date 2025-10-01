using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.AddEmployee;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

public partial class AddEmployeeMapper
{
    public partial AddEmployeeInput Map(AddEmployeeRequest request);
}
