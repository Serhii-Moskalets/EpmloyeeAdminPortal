using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Outputs;

public class GetAllEmployeeOutput
{
    public List<Employee> Employees { get; set; } = [];
}
