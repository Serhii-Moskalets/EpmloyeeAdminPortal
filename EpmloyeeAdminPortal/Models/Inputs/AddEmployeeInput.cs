using EpmloyeeAdminPortal.Models.Entities;

namespace EpmloyeeAdminPortal.Models.Inputs;

public class AddEmployeeInput
{
    public Employee Employee { get; set; } = null!;
}
