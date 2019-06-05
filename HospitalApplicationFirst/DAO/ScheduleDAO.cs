using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class ScheduleDAO : IDataAccessObject<Schedule>
    {
        private static ScheduleDAO instance = null;

        public static ScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScheduleDAO();

                return instance;
            }
        }

        private ScheduleDAO() { }

        public IEnumerable<Schedule> GetAll()
        {
            string query = "Select * from Schedules";

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

        public Schedule GetById(int id)
        {
            var query = string.Format($"Select * from schedules Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Schedule schedule = null;

                if (reader.Read())
                {
                    schedule = FillSchedule(reader);
                }

                return schedule;
            }
        }

        public void DeleteById(int id)
        {
            string query = "Delete From Schedules Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@id"] = id;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Insert(Schedule schedule)
        {
            string query = "INSERT INTO Schedules (Date, TimeStart, TimeEnd) VALUES (@Date, @TimeStart, @TimeEnd)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Date"] = schedule.Date;
                parameters["@TimeStart"] = schedule.TimeStart;
                parameters["@TimeEnd"] = schedule.TimeEnd;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Schedule schedule)
        {
            string query = "Update Schedules Set Date = @Date, TimeStart = @TimeStart, TimeEnd = @TimeEnd Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Date"] = schedule.Date;
                parameters["@TimeStart"] = schedule.TimeStart;
                parameters["@TimeEnd"] = schedule.TimeEnd;
                parameters["@Id"] = schedule.Id;

                dbConnector.ExecuteQuery(query, parameters);
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