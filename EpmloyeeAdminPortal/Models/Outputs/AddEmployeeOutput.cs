using EpmloyeeAdminPortal.Models.Entities;
using TinyResult;

namespace EpmloyeeAdminPortal.Models.Outputs;

public class AddEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}