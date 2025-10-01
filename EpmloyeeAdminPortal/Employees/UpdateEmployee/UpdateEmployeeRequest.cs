using System.Text.Json.Serialization;
using EmployeeAdminPortal.Employees.UpdateEmployee.Dtos;

namespace EmployeeAdminPortal.Employees.UpdateEmployee;

public class UpdateEmployeeRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public EmployeeDto Employee { get; set; } = null!;
}
