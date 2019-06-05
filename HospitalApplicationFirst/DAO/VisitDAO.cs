using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class VisitDAO : IDataAccessObject<Visit>
    {
        private static VisitDAO instance = null;

        public static VisitDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new VisitDAO();

                return instance;
            }
        }

        private VisitDAO() { }

        public IEnumerable<Visit> GetAll()
        {
            string query = "Select * from Visits";

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Visit> visits = new List<Visit>();

                while (reader.Read())
                {
                    var visit = FillVisit(reader);

                    if (visit != null)
                    {
                        visits.Add(visit);
                    }
                }

                return visits;
            }
        }

       
        public Visit GetById(int id)
        {
            var query = string.Format($"Select * from Visits Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Visit visit = null;

                if (reader.Read())
                {
                    visit = FillVisit(reader);
                }

                return visit;
            }
        }


        public void DeleteById(int id)
        {
            string query = "Delete From Roles Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@id"] = id;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Insert(Visit visit)
        {
            string query = "INSERT INTO Roles (Diagnosis, Preparation, Date, EmloyeeId, UserId, isFinished) " +
                                      "VALUES (@Diagnosis, @Preparation, @Date, @EmployeeId, @UserId, @isFinished)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Diagnosis"] = visit.Diagnosis;
                parameters["@Preparation"] = visit.Preparation;
                parameters["@Date"] = visit.Date;
                parameters["@EmployeeId"] = visit.EmployeeId;
                parameters["@UserId"] = visit.UserId;
                parameters["@isFinished"] = visit.isFinished;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Visit visit)
        {
            string query = "Update Visits Set Diagnosis = @Diagnosis, Preparation = @Preparation, Date = @Date, EmployeeId = @EmployeeId," +
                                            " UserId = @UserId, isFinished = @isFinished Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Diagnosis"] = visit.Diagnosis;
                parameters["@Preparation"] = visit.Preparation;
                parameters["@Date"] = visit.Date;
                parameters["@EmployeeId"] = visit.EmployeeId;
                parameters["@UserId"] = visit.UserId;
                parameters["@isFinished"] = visit.isFinished;
                parameters["@Id"] = visit.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }


        public Visit FillVisit(SqlDataReader reader)
        {
            var visit = new Visit();

            visit.Id = Convert.ToInt32(reader["Id"]);
            visit.Diagnosis = reader["Diagnosis"].ToString();
            visit.Preparation = reader["Preparation"].ToString();
            visit.UserId = Convert.ToInt32(reader["UserId"]);
            visit.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
            visit.Date = Convert.ToDateTime(reader["Date"]);
            visit.isFinished = Convert.ToBoolean(reader["isFinished"]);

            return visit;
        }
    }
}