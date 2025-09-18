using EpmloyeeAdminPortal.Models.Entities;

namespace EpmloyeeAdminPortal.Models.Inputs;

public class UpdateEmployeeInput
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}
