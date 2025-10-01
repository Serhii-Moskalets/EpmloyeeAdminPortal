using TinyResult;

namespace EmployeeAdminPortal.Models.Outputs;

public class DeleteEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}
