using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCProject.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get => FirstName + LastName; }
        public string Gender { get; set; }
        public AddressModel HomeAddress { get; set; }
    }
}