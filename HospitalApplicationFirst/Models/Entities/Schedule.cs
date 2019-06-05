using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public Schedule() { }
    }
}