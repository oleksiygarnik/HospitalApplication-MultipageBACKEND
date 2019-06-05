using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class RoleDAO : IDataAccessObject<Role>
    {
        private static RoleDAO instance = null;


        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoleDAO();

                return instance;
            }
        }

        private RoleDAO() { }

        public Role GetById(int id)
        {
            var query = string.Format($"Select * from Roles Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Role role = null;

                if (reader.Read())
                {
                    role = FillRole(reader);
                }

                return role;
            }
        }

        public Role GetRoleByName(string name)
        {
            var query = string.Format($"Select * from Roles Where Name = {name}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Role role = null;

                if (reader.Read())
                {
                    role = FillRole(reader);
                }

                return role;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            string query = "Select * from Roles";

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Role> roles = new List<Role>();

                while (reader.Read())
                {
                    var role = FillRole(reader);

                    if (role != null)
                    {
                        roles.Add(role);
                    }
                }

                return roles;
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

        public void Insert(Role role)
        {
            string query = "INSERT INTO Roles (Name) VALUES (@Name)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = role.Name;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Role role)
        {
            string query = "Update Roles Set Name = @Name Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = role.Name;
                parameters["@Id"] = role.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }



        public Role FillRole(SqlDataReader reader)
        {
            var role = new Role();

            role.Id = Convert.ToInt32(reader["Id"]);
            role.Name = reader["Name"].ToString();

            return role;
        }
    }
}