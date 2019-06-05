using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public int RoleId { get; set; }

        public int SpecialtyId { get; set; }

        public int DepartmentId { get; set; }

        public Employee() { }
    }
}