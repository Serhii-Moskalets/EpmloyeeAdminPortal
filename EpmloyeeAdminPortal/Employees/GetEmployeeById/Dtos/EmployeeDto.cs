namespace EmployeeAdminPortal.Employees.GetEmployeeById.Dtos;

public class EmployeeDto
{
    required public string Name { get; set; }

    required public string Email { get; set; }

    public string? Phone { get; set; }

    public decimal Salary { get; set; }
}
