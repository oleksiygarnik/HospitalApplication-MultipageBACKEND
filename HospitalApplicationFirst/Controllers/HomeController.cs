//using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalApplicationFirst.Controllers
{
    public class HomeController : Controller
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
            var key = FormsAuthentication.Authenticate.User;
            var employee = EmployeeService.Instance.GetEmployeeById(id);

            return View(employee);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Record(int id)
        {
            var employee = EmployeeService.Instance.GetEmployeeById(id);

            return View(employee);
        }
        [HttpPost]
        public ActionResult Record(Visit visit)
        {
            UserService.Instance.RecordToDoctor(visit);

            return null;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}