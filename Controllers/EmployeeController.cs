using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Payroll.Entity;
using Payroll.Models;
using Payroll.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Payroll.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly HostingEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, HostingEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
                 {
                        Id = employee.Id,
                        EmployeeNo = employee.EmployeeNo,
                        ImageUrl = employee.ImageUrl,
                        FullName = employee.FullName,
                        Gender = employee.Gender,
                        Designtion = employee.Designation,
                        Address = employee.Address,
                        PhoneNumber = employee.PhoneNumber,
                        DateJoined = employee.DateJoined
                 }).ToList();

            return View(employees);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    PhoneNumber = model.PhoneNumber,
                    DLNumber = model.DLNumber,
                    PaymentMethod = model.PaymentMethod,
                    EmployeeLoan = model.EmployeeLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    PostCode = model.PostCode,
                    Designation = model.Designation
                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDirectory = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var contentRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yyyymmssfff") + fileName + extension;
                    var path = Path.Combine(contentRootPath, uploadDirectory, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee ==null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                PhoneNumber = employee.PhoneNumber,
                DLNumber = employee.DLNumber,
                PaymentMethod = employee.PaymentMethod,
                EmployeeLoan = employee.EmployeeLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PostCode = employee.PostCode,
                Designation = employee.Designation
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);
                if (employee ==null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.DateJoined = model.DateJoined;
                employee.PaymentMethod = model.PaymentMethod;
                employee.EmployeeLoan = model.EmployeeLoan;
                employee.UnionMember = model.UnionMember;
                employee.DLNumber = model.DLNumber;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.PostCode = model.PostCode;
                employee.Designation = model.Designation;

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDirectory = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var contentRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yyyymmssfff") + fileName + extension;
                    var path = Path.Combine(contentRootPath, uploadDirectory, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;
                }

                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));

            }
            return View();
        }




        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                PhoneNumber = employee.PhoneNumber,
                DLNumber = employee.DLNumber,
                PaymentMethod = employee.PaymentMethod,
                EmployeeLoan = employee.EmployeeLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PostCode = employee.PostCode,
                Designation = employee.Designation,
                ImageUrl = employee.ImageUrl

            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
