using EpmloyeeAdminPortal.Employees.AddEmployee.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.AddEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class AddEmployeeMapper
    {
        public partial AddEmployeeInput Map(Request request);

        public partial Employee Map(EmployeeDto dto);
    }
}
