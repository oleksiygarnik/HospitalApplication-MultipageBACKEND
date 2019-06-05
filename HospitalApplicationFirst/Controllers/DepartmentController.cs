using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApplicationFirst.Controllers
{
    [Authorize]
    public class DepartmnetController : Controller
    {
        
        public ActionResult Index()
        {
            var departments = DepartmentService.Instance.GetAllDepartments();

            return View(departments);
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            DepartmentService.Instance.AddDepartment(department);

            return View();
        }


        [HttpGet]
        public ActionResult EditDepartment(int? id)
        {
            var department = DepartmentService.Instance.GetDepartmentById(id.Value);

            return View(department);
        }


        [HttpPut]
        public ActionResult EditDepartment(Department department)
        {
            DepartmentService.Instance.CorrectInformation(department);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            DepartmentService.Instance.RemoveDepartment(id);

            return RedirectToAction("Index");
        }
    }
}