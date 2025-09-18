using EpmloyeeAdminPortal.Models.Entities;

namespace EpmloyeeAdminPortal.Models.Outputs;

public class GetAllEmployeeOutput
{
    public List<Employee> Employees { get; set; } = [];
}
