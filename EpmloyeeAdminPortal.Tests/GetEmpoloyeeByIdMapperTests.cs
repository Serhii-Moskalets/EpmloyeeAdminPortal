using EpmloyeeAdminPortal.Employees.GetEmployee;
using EpmloyeeAdminPortal.Employees.GetEmployee.Dtos;
using EpmloyeeAdminPortal.Employees.GetEmpoloyeeById;
using EpmloyeeAdminPortal.Models.Entities;
using EpmloyeeAdminPortal.Models.Outputs;

namespace EpmloyeeAdminPortal.Tests;

[TestClass]
public class GetEmpoloyeeByIdMapperTests
{
    private GetEmpoloyeeByIdMapper _mapper = null!;

    [TestInitialize]
    public void Setup()
    {
        this._mapper = new GetEmpoloyeeByIdMapper();
    }

    [TestMethod]
    public void EmployeeDto_To_Employee_Mapping_Works()
    {
        var dto = new EmployeeDto
        {
            Name = "John",
            Email = "john@example.com",
            Phone = "123456789",
            Salary = 1000,
        };

        var entity = this._mapper.Map(dto);

        Assert.IsNotNull(entity);
        Assert.AreEqual(dto.Name, entity.Name);
        Assert.AreEqual(dto.Email, entity.Email);
        Assert.AreEqual(dto.Phone, entity.Phone);
        Assert.AreEqual(dto.Salary, entity.Salary);
    }

    [TestMethod]
    public void Employee_To_EmployeeDto_Mapping_Works()
    {
        var entity = new Employee
        {
            Name = "Jane",
            Email = "jane@example.com",
            Phone = "987654321",
            Salary = 2000,
        };

        var dto = this._mapper.Map(entity);

        Assert.IsNotNull(dto);
        Assert.AreEqual(entity.Name, dto.Name);
        Assert.AreEqual(entity.Email, dto.Email);
        Assert.AreEqual(entity.Phone, dto.Phone);
        Assert.AreEqual(entity.Salary, dto.Salary);
    }

    [TestMethod]
    public void GetEmpoloyeeByIdRequest_To_Input_Mapping_Works()
    {
        var request = new GetEmpoloyeeByIdRequest { Id = Guid.NewGuid() };

        var input = this._mapper.Map(request);

        Assert.AreEqual(request.Id, input.Id);
    }

    [TestMethod]
    public void Output_To_Response_Mapping_Works()
    {
        var output = new GetEmployeeByIdOutput
        {
            Employee = new Employee
            {
                Name = "Alice",
                Email = "alice@example.com",
                Phone = "555555",
                Salary = 1500,
                IsDeleted = false
            }
        };

        var response = this._mapper.Map(output);

        Assert.IsNotNull(response);
        Assert.AreEqual(output.Employee.Name, response.Employee!.Name);
        Assert.AreEqual(output.Employee.Email, response.Employee.Email);
    }
}
