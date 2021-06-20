using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.VM
{
    public class EmployeeVM : Models.Employee
    {
        [Display(Name ="First name")]
        public string FirstName { get; set; }
        [Display(Name ="Last name")]
        public string LastName { get; set; }
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Age")]
        public int age { get; set; }
    }
}