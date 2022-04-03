using SimpleMVCProject.Models;
using SimpleMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class StudentController : Controller
    {
        private POSDBContext posDBContext;

        public StudentController()
        {
            posDBContext = new POSDBContext();
        }

        //GET: Student
        public ActionResult List()
        {
            List<StudentViewModel> stuViewModels = posDBContext.Students.Select(s => new StudentViewModel
            {
                Id = s.Id,
                No = s.No,
                Name = s.Name,
                Email = s.Email,
                DOB = s.DOB,
                Address = s.Address,            
                FatherName = s.FatherName
            }).ToList();
            return View(stuViewModels);
        }

        public ActionResult Entry()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Entry(StudentViewModel studentViewModel)
        {
            StudentModel studentModel = new StudentModel()
            {
                Id = Guid.NewGuid().ToString(),
                No = studentViewModel.No,
                Name = studentViewModel.Name,             
                Email = studentViewModel.Email,
                DOB = studentViewModel.DOB,
                Address = studentViewModel.Address,
                FatherName = studentViewModel.FatherName
            };
            posDBContext.Students.Add(studentModel);
            int result = posDBContext.SaveChanges();
            if (result > 0)
            {
                ViewBag.result = "Save success";
            }
            else
            {
                ViewBag.result = "Save failed";
            }
            //return View();
            return RedirectToAction("List");
        }


        public ActionResult Delete(string studentId)
        {
            StudentModel studentModel = posDBContext.Students.Where(x => x.Id == studentId).FirstOrDefault();
            if (studentModel != null)
            {
                posDBContext.Students.Remove(studentModel);
                posDBContext.SaveChanges();
                ViewBag.result = "Delete successfully";
            }
            return RedirectToAction("List");
        }


        public ActionResult Edit(string studentId)
        {
            var studentViewModel = posDBContext.Students.Where(x => x.Id == studentId).Select(s => new StudentViewModel
            {
                Id = s.Id,
                No = s.No,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                DOB = s.DOB,
                FatherName = s.FatherName
            }).SingleOrDefault();
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            StudentModel studentModel = new StudentModel()
            {
                Id = studentViewModel.Id,
                No = studentViewModel.No,
                Name = studentViewModel.Name,
                Email = studentViewModel.Email,
                DOB = studentViewModel.DOB,
                Address = studentViewModel.Address,
                FatherName = studentViewModel.FatherName,
                UpdatedDate = DateTime.Now
            };
            //by importing this library >> System.Data.Entity.Migrations;
            posDBContext.Students.AddOrUpdate(studentModel);
            int result = posDBContext.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("List");
            }
            return View();
        }

    }
}