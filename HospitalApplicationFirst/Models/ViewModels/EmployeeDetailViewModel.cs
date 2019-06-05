using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.Models.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }
    }
}