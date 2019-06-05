//using HospitalApplicationFirst.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace HospitalApplicationFirst.Controllers
//{
//    public class VisitController : Controller
//    {
//        // history/index
//        [HttpGet]
//        [Authorize]
//        public ActionResult Index()
//        {
//            var visits = VisitService.Instance.GetAllVisitsForUser(5); //lol

//            return View(visits);
//        }

//        [HttpGet]
//        [Authorize]
//        public ActionResult Edit(int? id)
//        {a
//            if (id == null)
//            {
//                return HttpNotFound();
//            }
//            Visit visit = _User
//            if (tour != null)
//            {
//                return View(tour);
//            }
//            return HttpNotFound();
//        }


//        [HttpPost]
//        public ActionResult Edit(Tour tour)
//        {
//            db.Entry(tour).State = EntityState.Modified;
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}