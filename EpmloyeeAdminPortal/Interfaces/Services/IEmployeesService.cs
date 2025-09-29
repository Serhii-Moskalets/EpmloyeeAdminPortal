using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;
using TinyResult;

namespace EpmloyeeAdminPortal.Interfaces.Services;

public interface IEmployeesService
{
    Task<GetAllEmployeeOutput> GetAllEmployeesAsync();
    Task<GetEmployeeByIdOutput> GetEmployeeByIdAsync(GetEmployeeByIdInput input);
    Task<Result<bool>> AddEmployeeAsync(AddEmployeeInput input);
    Task<Result<bool>> UpdateEmployeeAsync(UpdateEmployeeInput input);
    Task<Result<bool>> DeleteEmployeeAsync(DeleteEmployeeInput input);
}
