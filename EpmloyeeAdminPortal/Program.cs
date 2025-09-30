using EpmloyeeAdminPortal.Data;
using EpmloyeeAdminPortal.Employees.AddEmployee;
using EpmloyeeAdminPortal.Employees.UpdateEmployee;
using EpmloyeeAdminPortal.Extentions;
using EpmloyeeAdminPortal.Services.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDataServices();

builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type =>
    {
        // Використовуємо повний неймспейс як унікальне ім’я
        return type.FullName!.Replace(".", "_");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
