using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Services;

namespace EpmloyeeAdminPortal.Extentions;

public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services.AddScoped<IEmployeesService, EmployeesService>();
    }
}
