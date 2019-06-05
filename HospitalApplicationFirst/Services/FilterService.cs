using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using HospitalApplicationFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class FilterService
    {
        private static FilterService instance = null;

        public static FilterService Instance
        {
            get
            {
                if (instance == null)
                    instance = new FilterService();

                return instance;
            }
        }

        private FilterService() { }

        public IndexViewModel GetEmployeesByFilter(int? specialty, string name, int page = 1)
        {
            int pageSize = 3;

            IEnumerable<Employee> employees = EmployeeDAO.Instance.GetAll();

            if (specialty != null && specialty != 0)
            {
                employees = employees.Where(p => p.SpecialtyId == specialty);
            }
            if (!String.IsNullOrEmpty(name))
            {
                employees = employees.Where(p => p.Firstname.Contains(name));
            }

            var count = employees.Count();
            var items = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var specialties = SpecialtyDAO.Instance.GetAll().ToList();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterViewModel(specialties, specialty, name),
                Users = items
            };

            return viewModel;
        }
    }
}