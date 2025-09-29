using EpmloyeeAdminPortal.Employees.GetEmployee.Dtos;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.GetEmployee
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class GetEmployeeByIdMapper
    {
        public partial GetEmployeeByIdInput Map(GetEmployeeByIdRequest request);

        public partial GetEmployeeByIdResponse Map(GetEmployeeByIdOutput output);

        public partial Employee Map(EmployeeDto dto);

        public partial EmployeeDto Map(Employee entity);
    }
}
