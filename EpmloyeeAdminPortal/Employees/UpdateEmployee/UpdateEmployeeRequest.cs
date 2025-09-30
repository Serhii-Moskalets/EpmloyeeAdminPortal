using System.Text.Json.Serialization;
using EpmloyeeAdminPortal.Employees.UpdateEmployee.Dtos;

namespace EpmloyeeAdminPortal.Employees.UpdateEmployee
{
    public class UpdateEmployeeRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public EmployeeDto Employee { get; set; } = null!;
    }
}
