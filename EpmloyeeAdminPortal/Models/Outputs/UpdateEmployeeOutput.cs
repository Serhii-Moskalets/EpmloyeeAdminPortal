using TinyResult;

namespace EmployeeAdminPortal.Models.Outputs;

public class UpdateEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}
