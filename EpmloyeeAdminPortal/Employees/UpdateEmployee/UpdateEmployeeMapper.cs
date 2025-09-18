using EpmloyeeAdminPortal.Employees.UpdateEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.UpdateEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class UpdateEmployeeMapper
    {
        public partial UpdateEmployeeInput Map(Request request);

        public partial Response Map(UpdateEmployeeOutput output);

        public partial Employee Map(EmployeeDto dto);

        public partial EmployeeDto Map(Employee entity);
    }
}
