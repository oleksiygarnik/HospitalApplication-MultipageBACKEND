using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HospitalApplicationFirst.Services
{
    public class AuthService
    {
        private static AuthService instance = null;

        public static AuthService Instance
        {
            get
            {
                if (instance == null)
                    instance = new AuthService();

                return instance;
            }
        }

        private AuthService() { }

        public bool IsUserContainsByEmail(string email)
        {
            User checkUser = UserDAO.Instance.GetUserByEmail(email);

            if (checkUser == null)
                return false;

            return true;
        }

        public void SignIn(string email)
        {
            
            FormsAuthentication.SetAuthCookie(email, true);
        }
    }
}