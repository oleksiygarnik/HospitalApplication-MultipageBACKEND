using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.ViewModels;
using HospitalApplicationFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalApplicationFirst.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {   
                if (AuthService.Instance.IsUserContainsByEmail(model.Email))
                {
                    AuthService.Instance.SignIn(model.Email);
                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(model);
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!AuthService.Instance.IsUserContainsByEmail(model.Email))
                {
                    UserService.Instance.CreateNewUserByRegister(model);

                    AuthService.Instance.SignIn(model.Email);

                    return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    ModelState.AddModelError("", "Данный пользователь уже зарегистрирован на сайте");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}