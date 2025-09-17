using EpmloyeeAdminPortal.Employees.UpdateEmployee.Dtos;
using System.Text.Json.Serialization;

namespace EpmloyeeAdminPortal.Employees.UpdateEmployee
{
    public class Request
    {
        [JsonIgnore]
        public Guid EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; } = null!;
    }
}
