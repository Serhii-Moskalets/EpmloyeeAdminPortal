using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Services;

namespace EpmloyeeAdminPortal.Extentions;

public static class DataExtentions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services.AddScoped<IEmployeesService, EmployeesService>();
    }

}
