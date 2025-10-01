using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Outputs;

public class GetEmployeeByIdOutput
{
    public Employee? Employee { get; set; } = null!;
}
