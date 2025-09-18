using EpmloyeeAdminPortal.Employees.DeleteEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.DeleteEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class DeleteEmployeeMapper
    {
        public partial DeleteEmployeeInput Map(DeleteEmployeeRequest request);

        public partial Employee Map(EmployeeDto dto);
    }
}
