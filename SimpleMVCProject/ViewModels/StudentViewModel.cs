using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCProject.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }

        public List<StudentViewModel> GetDataSource()
        {
            return new List<StudentViewModel>();
        }
    }
}