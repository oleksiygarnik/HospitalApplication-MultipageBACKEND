using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class EmployeeScheduleDAO
    {
        private static EmployeeScheduleDAO instance = null;

        public static EmployeeScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeScheduleDAO();

                return instance;
            }
        }

        private EmployeeScheduleDAO() { }

        public IEnumerable<Schedule> GetSchedulesByEmployeeId(int id)
        {
            var query = string.Format($"Select * from EmployeeSchedules Where EmployeeId = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Schedule> schedules = new List<Schedule>();

                while (reader.Read())
                {
                    var schedule = FillSchedule(reader);

                    if (schedule != null)
                    {
                        schedules.Add(schedule);
                    }
                }

                return schedules;
            }
        }


        public Schedule FillSchedule(SqlDataReader reader)
        {
            var schedule = new Schedule();

            schedule.Id = Convert.ToInt32(reader["Id"]);
            schedule.Date = Convert.ToDateTime(reader["Date"]);
            schedule.TimeStart = Convert.ToDateTime(reader["TimeStart"]);
            schedule.TimeEnd = Convert.ToDateTime(reader["TimeEnd"]);

            return schedule;
        }
    }
}