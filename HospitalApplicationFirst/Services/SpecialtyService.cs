using HospitalApplicationFirst.DAO;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Services
{
    public class SpecialtyService
    {
        private static SpecialtyService instance = null;

        public static SpecialtyService Instance
        {
            get
            {
                if (instance == null)
                    instance = new SpecialtyService();

                return instance;
            }
        }

        private SpecialtyService() { }

        public void AddSpecialty(Specialty specialty)
        {
            SpecialtyDAO.Instance.Insert(specialty);
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return SpecialtyDAO.Instance.GetAll();
        }

        public Specialty GetSpecialtyById(int id)
        {
            return SpecialtyDAO.Instance.GetById(id);
        }

        public void CorrectInformation(Specialty specialty)
        {
            SpecialtyDAO.Instance.Update(specialty);
        }

        public void RemoveSpecialty(int id)
        {
            SpecialtyDAO.Instance.DeleteById(id);
        }
    }
}