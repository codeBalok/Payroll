using Payroll.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; } 
        public string EmployeeNo { get; set; }            
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }       
        public string Email { get; set; }     
        public string PhoneNumber { get; set; }
        public string DLNumber { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public EmployeeLoan EmployeeLoan { get; set; }
        public UnionMember UnionMember { get; set; }     
        public string Address { get; set; } 
        public string City { get; set; }  
        public string PostCode { get; set; }

    }
}
