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
    public class SpecialtyController : Controller
    {

        public ActionResult Index()
        {
            var specialties = SpecialtyService.Instance.GetAllSpecialties();

            return View(specialties);
        }

        [HttpGet]
        public ActionResult CreateSpecialty()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty)
        {
            SpecialtyService.Instance.AddSpecialty(specialty);

            return View();
        }


        [HttpGet]
        public ActionResult EditSpecialty(int? id)
        {
            var specialty = SpecialtyService.Instance.GetSpecialtyById(id.Value);

            if(specialty == null)
            {
                return HttpNotFound();
            }

            return View(specialty);
        }


        [HttpPut]
        public ActionResult EditSpecialty(Specialty specialty)
        {
            SpecialtyService.Instance.CorrectInformation(specialty);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteSpecialty(int id)
        {
            SpecialtyService.Instance.RemoveSpecialty(id);

            return RedirectToAction("Index");
        }
    }
}