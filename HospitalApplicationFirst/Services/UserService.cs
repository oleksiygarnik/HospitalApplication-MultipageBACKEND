using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class UserService
    {
        private static UserService instance = null;

        public static UserService Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserService();

                return instance;
            }
        }

        private UserService() { }

        public void CreateNewUserByRegister(RegisterModel model)
        {
            User user = new User {
                Firstname = model.Firstname,
                Password = model.Password,
                Email = model.Email,
                Patronymic = model.Patronymic,
                Surname = model.Surname };

            UserDAO.Instance.Insert(user);

        }

        public void RegisterUserLikeEmployee(User user)
        {
            var role = RoleDAO.Instance.GetRoleByName("Employee");

            UserDAO.Instance.DeleteById(user.Id);

            Employee employee = new Employee()
            {
                Firstname = user.Firstname,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Email = user.Email,
                Password = user.Password,
                RoleId = role.Id
            };

            UserDAO.Instance.DeleteById(user.Id);

            EmployeeDAO.Instance.Insert(employee);
        }

        public IEnumerable<Visit> GetHistoryVisitsForUser(int id)
        {
             var visits = VisitDAO.Instance.GetAll();

            return visits.Where(v => v.UserId == id);
        }

        public void RecordToDoctor(Visit visit)
        {
            visit.isFinished = false;

            VisitDAO.Instance.Insert(visit);
        }
    }
}