using EpmloyeeAdminPortal.Models.Entities;

namespace EpmloyeeAdminPortal.Models.Inputs;

public class UpdateEmployeeInput
{
    public Guid Id { get; set; }

    public Employee Employee { get; set; } = null!;
}
