namespace EpmloyeeAdminPortal.Models.Entities;

public class Employee
{
    public Guid EmployeeId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email {  get; set; }
    public string? Phone { get; set; }
    public decimal Salary { get; set; }
    public bool IsDeleted { get; set; } = false;
}
