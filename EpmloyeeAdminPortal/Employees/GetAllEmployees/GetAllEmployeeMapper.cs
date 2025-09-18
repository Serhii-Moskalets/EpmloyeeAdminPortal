using EpmloyeeAdminPortal.Employees.GetAllEmployees.Dtos;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EpmloyeeAdminPortal.Employees.GetEmpoloyeeById
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class GetAllEmployeeMapper
    {
        public partial Response Map(GetAllEmployeeOutput output);
        public partial Employee Map(EmployeeDto dto);

    }
}
