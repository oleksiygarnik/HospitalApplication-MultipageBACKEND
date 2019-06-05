using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class SpecialtyDAO : IDataAccessObject<Specialty>
    {
        private static SpecialtyDAO instance = null;

        public static SpecialtyDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SpecialtyDAO();

                return instance;
            }
        }

        private SpecialtyDAO() { }

        public IEnumerable<Specialty> GetAll()
        {
            string query = "Select * from Specialties";

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Specialty> specialties = new List<Specialty>();

                while (reader.Read())
                {
                    var specialty = FillSpecialty(reader);

                    if (specialty != null)
                    {
                        specialties.Add(specialty);
                    }
                }

                return specialties;
            }
        }

        public Specialty GetById(int id)
        {
            var query = string.Format($"Select * from Specialties Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Specialty specialty = null;

                if (reader.Read())
                {
                    specialty = FillSpecialty(reader);
                }

                return specialty;
            }
        }

      

        public void DeleteById(int id)
        {
            string query = "Delete From Specialties Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@id"] = id;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Insert(Specialty specialty)
        {
            string query = "INSERT INTO Specialties (Name) VALUES (@Name)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = specialty.Name;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Specialty specialty)
        {
            string query = "Update Specialties Set Name = @Name Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = specialty.Name;
                parameters["@Id"] = specialty.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }

        public Specialty FillSpecialty(SqlDataReader reader)
        {
            var specialty = new Specialty();

            specialty.Id = Convert.ToInt32(reader["Id"]);
            specialty.Name = reader["Name"].ToString();

            return specialty;
        }

    }
}