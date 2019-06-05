using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class VisitService
    {
        private static VisitService instance = null;

        public static VisitService Instance
        {
            get
            {
                if (instance == null)
                    instance = new VisitService();

                return instance;
            }
        }

        private VisitService() { }

        public Visit GetVisitById(int id)
        {
            var visit = VisitDAO.Instance.GetById(id);

            return visit;
        }

        public IEnumerable<Visit> GetAllVisitsForUser(int id)
        {
            var visits = VisitDAO.Instance.GetAll();

            return visits.Where(v => v.UserId == id);
        }

        public IEnumerable<Visit> GetAllVisitsForEmployee(int id)
        {
            var visits = VisitDAO.Instance.GetAll();

            return visits.Where(v => v.EmployeeId == id);
        }


    }
}