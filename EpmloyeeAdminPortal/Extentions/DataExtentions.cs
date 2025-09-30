using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.UpdateEmployee;
using EpmloyeeAdminPortal.Interfaces.Services;
using EpmloyeeAdminPortal.Models.Inputs;
using EpmloyeeAdminPortal.Services;
using EpmloyeeAdminPortal.Services.Validators;
using FluentValidation;

namespace EpmloyeeAdminPortal.Extentions;

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
