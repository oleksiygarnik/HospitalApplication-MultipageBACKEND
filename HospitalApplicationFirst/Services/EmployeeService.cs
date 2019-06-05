using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class EmployeeService
    {
        private static EmployeeService instance = null;

        public static EmployeeService Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeService();

                return instance;
            }
        }

        private EmployeeService() { }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = EmployeeDAO.Instance.GetAll();

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = EmployeeDAO.Instance.GetById(id);

            return employee;
        }

        public void LayOffEmployee(int id)
        {
            var employee = EmployeeDAO.Instance.GetById(id);

            var role = RoleDAO.Instance.GetRoleByName("User");

            User user = new User()
            {
                Firstname = employee.Firstname,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Password = employee.Password,
                RoleId = role.Id
            };

            EmployeeDAO.Instance.DeleteById(id);

            UserDAO.Instance.Insert(user);
        }

        public void RegisterEmployee(Employee employee)
        {
            EmployeeDAO.Instance.Insert(employee);
        }

        public void UpdateInformationInEmployee(Employee employee)
        {
            EmployeeDAO.Instance.Update(employee);
        }

        public Specialty GetSpecialtyByEmployeeId(int id)
        {
            var employee = EmployeeDAO.Instance.GetById(id);

            var specialty = SpecialtyDAO.Instance.GetById(employee.SpecialtyId);

            return specialty;
        }

        public Department GetDepartmentByEmployeeId(int id)
        {
            var employee = EmployeeDAO.Instance.GetById(id);

            var department = DepartmentDAO.Instance.GetById(employee.DepartmentId);

            return department;
        }

        public IEnumerable<Schedule> GetSchedulesByEmployeeId(int id)
        {
            var employee = EmployeeDAO.Instance.GetById(id);

            IEnumerable<Schedule> schedules = EmployeeScheduleDAO.Instance.GetSchedulesByEmployeeId(id);

            return schedules;
        }

        public IEnumerable<Visit> GetClientsForEmployee(int EmployeeId)
        {
            var visits = VisitDAO.Instance.GetAll();

            return visits.Where(v => v.EmployeeId == EmployeeId);
        }
    }
}