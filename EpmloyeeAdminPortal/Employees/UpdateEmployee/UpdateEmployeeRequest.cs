using EpmloyeeAdminPortal.Employees.UpdateEmployee.Dtos;
using System.Text.Json.Serialization;

namespace EpmloyeeAdminPortal.Employees.UpdateEmployee
{
    public class UpdateEmployeeRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public EmployeeDto Employee { get; set; } = null!;
    }
}
