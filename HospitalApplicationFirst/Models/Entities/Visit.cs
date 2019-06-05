using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Models.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        public bool isFinished { get; set; }

        public DateTime Date { get; set; }

        public string Diagnosis { get; set; }

        public string Preparation { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public Visit() { }
    }
}