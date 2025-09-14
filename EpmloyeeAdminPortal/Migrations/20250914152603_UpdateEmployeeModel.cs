using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpmloyeeAdminPortal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employess",
                table: "Employess");

            migrationBuilder.RenameTable(
                name: "Employess",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employess");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employess",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employess",
                table: "Employess",
                column: "Id");
        }
    }
}
