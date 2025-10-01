using TinyResult;

namespace EmployeeAdminPortal.Models.Outputs;

public class AddEmployeeOutput
{
    public Result<bool> Result { get; set; } = null!;
}