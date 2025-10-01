using EmployeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.DeleteEmployee;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

public partial class DeleteEmployeeMapper
{
    public partial DeleteEmployeeInput Map(DeleteEmployeeRequest request);
}
