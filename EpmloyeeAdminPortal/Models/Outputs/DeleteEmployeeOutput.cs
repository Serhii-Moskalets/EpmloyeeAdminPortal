using TinyResult;

namespace EpmloyeeAdminPortal.Models.Outputs;

public class DeleteEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}
