using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using TinyResult;

namespace EmployeeAdminPortal.Interfaces.Services;

public interface IEmployeesService
{
    Task<GetAllEmployeeOutput> GetAllEmployeesAsync();

    Task<Result<GetEmployeeByIdOutput>> GetEmployeeByIdAsync(GetEmployeeByIdInput input);

    Task<Result<bool>> AddEmployeeAsync(AddEmployeeInput input);

    Task<Result<bool>> UpdateEmployeeAsync(UpdateEmployeeInput input);

    Task<Result<bool>> DeleteEmployeeAsync(DeleteEmployeeInput input);
}
