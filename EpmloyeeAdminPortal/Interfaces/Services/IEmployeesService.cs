using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;

namespace EpmloyeeAdminPortal.Interfaces.Services;

public interface IEmployeesService
{
    Task<GetAllEmployeeOutput> GetAllEmployeesAsync();
    Task<GetEmployeeByIdOutput> GetEmployeeByIdAsync(GetEmployeeByIdInput input);
    Task<AddEmployeeOutput> AddEmployeeAsync(AddEmployeeInput input);
    Task<UpdateEmployeeOutput> UpdateEmployeeAsync(UpdateEmployeeInput input);
    Task<DeleteEmployeeOutput> DeleteEmployeeAsync(DeleteEmployeeInput input);
}
