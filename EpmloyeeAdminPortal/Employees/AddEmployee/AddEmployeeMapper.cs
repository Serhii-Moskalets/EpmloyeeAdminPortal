using EpmloyeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.AddEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Source)]

    public partial class AddEmployeeMapper
    {
        public partial AddEmployeeInput Map(AddEmployeeRequest request);
    }
}
