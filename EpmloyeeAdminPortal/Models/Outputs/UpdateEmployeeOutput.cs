using EpmloyeeAdminPortal.Models.Entities;
using TinyResult;

namespace EpmloyeeAdminPortal.Models.Outputs;

public class UpdateEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}
