using EpmloyeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.DeleteEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

    public partial class DeleteEmployeeMapper
    {
        public partial DeleteEmployeeInput Map(DeleteEmployeeRequest request);
    }
}
