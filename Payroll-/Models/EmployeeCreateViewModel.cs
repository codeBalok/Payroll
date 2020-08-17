using Microsoft.AspNetCore.Http;
using Payroll.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee Number is Requried"),RegularExpression(@"^[A-Z]{7,7}[0-9]{7}$")]
        public string EmployeeNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Requried"), StringLength(50, MinimumLength =2)]
            [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name ="First Name")]

        
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is Requried"), StringLength(50, MinimumLength = 2)]
            [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string FullName => FirstName + (string.IsNullOrEmpty(MiddleName)?" " : (" " + (char?)MiddleName[0] + ".").ToUpper()) + LastName;
        public string Gender { get; set; }
        [Display(Name ="Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name ="Data of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Data of Join")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage ="Job Role is Requried"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50), Display(Name ="Contact No. ")]
        [RegularExpression(@"^\d{4}-\d{3}-\d{3}$")]
        public string PhoneNumber { get; set; }

        public string DLNumber { get; set; }
        [Display(Name ="Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name ="Employee Loan")]
        public EmployeeLoan EmployeeLoan { get; set; }
        [Display(Name ="Union Member")]
        public UnionMember UnionMember { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        [Required, StringLength(150)]
        public string City { get; set; }
        [Required, MaxLength(50), Display(Name ="Post Code")]
        public string PostCode { get; set; }
        
      

    }
}
