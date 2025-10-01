using EmployeeAdminPortal.Employees.AddEmployee;
using EmployeeAdminPortal.Employees.UpdateEmployee;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Services;
using EmployeeAdminPortal.Services.Validators;
using FluentValidation;

namespace EmployeeAdminPortal.Extentions;

public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesService, EmployeesService>();

        services.AddValidatorsFromAssemblyContaining<AddEmployeeValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateEmployeeValidator>();

        services.AddTransient<IValidator<GetEmployeeByIdInput>, GetEmployeeByIdInputValidator>();
        services.AddTransient<IValidator<UpdateEmployeeInput>, UpdateEmployeeInputValidator>();
        services.AddTransient<IValidator<DeleteEmployeeInput>, DeleteEmployeeInputValidator>();

        return services;
    }
}
