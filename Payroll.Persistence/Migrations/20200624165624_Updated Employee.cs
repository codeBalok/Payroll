using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll.Persistence.Migrations
{
    public partial class UpdatedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "designation",
                table: "Employees",
                newName: "Designation");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DLNumber",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DLNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Employees",
                newName: "designation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "designation",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
