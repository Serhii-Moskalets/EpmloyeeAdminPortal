using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Inputs;

public class AddEmployeeInput
{
    public Employee Employee { get; set; } = null!;
}
