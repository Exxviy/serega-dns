using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public string EmployeeSurName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeLogin { get; set; }
        public string EmployeePassword { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
    
        public string PhoneNumber { get; set; }
      
        public DateTime HireDate { get; set; }
    }

}
