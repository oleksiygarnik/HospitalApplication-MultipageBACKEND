using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApplicationFirst.Controllers
{
    public class VisitController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult ForUser()
        {
            string email = User.Identity.Name;

            var user = UserService.Instance.GetUserByEmail(email);

            var visits = VisitService.Instance.GetAllVisitsForUser(user.Id); 

            return View(visits);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ForEmployee()
        {
            string email = User.Identity.Name;

            var user = UserService.Instance.GetUserByEmail(email);

            var visits = VisitService.Instance.GetAllVisitsForEmployee(user.Id);

            return View(visits);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Visit visit = VisitService.Instance.GetVisitById(id.Value);

            if (visit != null)
            {
                return View(visit);
            }

            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Edit(Visit visit)
        {
            VisitService.Instance.UpdateVisit(visit);

            return RedirectToAction("Index");
        }
    }
}