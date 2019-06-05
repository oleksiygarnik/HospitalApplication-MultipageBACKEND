using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class DepartmentService
    {
        private static DepartmentService instance = null;

        public static DepartmentService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DepartmentService();

                return instance;
            }
        }

        private DepartmentService() { }

        public void AddDepartment(Department department)
        {
            DepartmentDAO.Instance.Insert(department);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return DepartmentDAO.Instance.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return DepartmentDAO.Instance.GetById(id);
        }

        public void CorrectInformation(Department department)
        {
            DepartmentDAO.Instance.Update(department);
        }

        public void RemoveDepartment(int id)
        {
            DepartmentDAO.Instance.DeleteById(id);
        }
    }
}