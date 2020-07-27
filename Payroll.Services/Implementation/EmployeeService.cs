using Microsoft.AspNetCore.Mvc.Rendering;
using Payroll.Entity;
using Payroll.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal empLoanAmount;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task CreateAsync(Employee newEmployee)
        {
           await _context.Employees.AddAsync(newEmployee);
           await _context.SaveChangesAsync();
        }


        public Employee GetById(int employeeId) => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
           await _context.SaveChangesAsync();
        }



        public IEnumerable<Employee> GetAll() => _context.Employees;



        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
           await _context.SaveChangesAsync();
        }



        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }


        public decimal EmpLoanRepaymentAmount(int id, decimal totalAmount)
        {

            var employee = GetById(id);
            if (employee.EmployeeLoan == EmployeeLoan.Yes && totalAmount > 1750 && totalAmount < 2000)
            {
                empLoanAmount = 200m;
            }
            else if (employee.EmployeeLoan == EmployeeLoan.Yes && totalAmount >=2000 && totalAmount <3000)
            {
                empLoanAmount = 250m;
            }
            else if (employee.EmployeeLoan == EmployeeLoan.Yes && totalAmount >= 3000 && totalAmount < 5000)
            {
                empLoanAmount = 350m;
            }
            else if (employee.EmployeeLoan == EmployeeLoan.Yes && totalAmount >= 5000 && totalAmount < 10000)
            {
                empLoanAmount = 400m;
            }
            else if (employee.EmployeeLoan == EmployeeLoan.Yes && totalAmount >= 15000)
            {
                empLoanAmount = 500m;
            }
            return empLoanAmount;
        }

        public decimal FeesDeduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
        }
    }
}
