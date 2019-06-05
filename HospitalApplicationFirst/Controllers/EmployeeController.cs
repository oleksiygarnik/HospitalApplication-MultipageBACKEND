//using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.ViewModels;
using HospitalApplicationFirst.Services;
using System.Web.Mvc;
using System.Web.Security;

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
        public ActionResult Employee(int id)
        {          
            var employee = EmployeeService.Instance.GetEmployeeById(id);

            EmployeeDetailViewModel viewModel = new EmployeeDetailViewModel();

            viewModel.Employee = employee;

            var schedules = EmployeeService.Instance.GetSchedulesByEmployeeId(employee.Id);

            viewModel.Schedules = schedules;

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Record(Visit visit)
        {
            string email = User.Identity.Name;

            UserService.Instance.RecordToDoctor(visit, email);

            return RedirectToAction("Index");
        }

        
    }
}