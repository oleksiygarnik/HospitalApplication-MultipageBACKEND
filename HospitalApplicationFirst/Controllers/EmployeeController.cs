using HospitalApplicationFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApplicationFirst.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? specialty, string name, int page = 1)
        {
            var viewModel = FilterService.Instance.GetEmployeesByFilter(specialty, name, page);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var employee = EmployeeService.Instance.GetEmployeeById(id);

            return View(employee);
        }
    }
}