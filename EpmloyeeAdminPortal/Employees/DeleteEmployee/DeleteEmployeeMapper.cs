using EpmloyeeAdminPortal.Employees.DeleteEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.DeleteEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class DeleteEmployeeMapper
    {
        public partial DeleteEmployeeInput Map(Request request);

        public partial EmployeeDto Map(Employee entity);
    }
}
