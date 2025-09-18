using EpmloyeeAdminPortal.Employees.UpdateEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.UpdateEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class UpdateEmployeeMapper
    {
        public partial UpdateEmployeeInput Map(UpdateEmployeeRequest request);

        public partial Employee Map(EmployeeDto dto);
    }
}
