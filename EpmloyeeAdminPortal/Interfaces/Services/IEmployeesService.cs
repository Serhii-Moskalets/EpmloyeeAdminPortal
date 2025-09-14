using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Models.Outputs;

namespace EpmloyeeAdminPortal.Interfaces.Services;

public interface IEmployeesService
{
    Task<List<GetEmployeeOutput>> GetAllEmployeesAsync();
    Task<GetEmployeeOutput?> GetEmployeeByIdAsync(Guid id);
    Task<GetEmployeeOutput> AddEmployeeAsync(EmployeeInput input);
    Task<GetEmployeeOutput?> UpdateEmployeeAsync(Guid id, EmployeeInput input);
    Task<GetEmployeeOutput?> DeleteEmployeeAsync(Guid id);
}
