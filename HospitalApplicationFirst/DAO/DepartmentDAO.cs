using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class DepartmentDAO : IDataAccessObject<Department>
    {
        private static DepartmentDAO instance = null;

        public static DepartmentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DepartmentDAO();

                return instance;
            }
        }

        private DepartmentDAO() { }

        public IEnumerable<Department> GetAll()
        {
            string query = "Select * from Departments";

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    var department = FillDepartment(reader);

                    if (department != null)
                    {
                        departments.Add(department);
                    }
                }

                return departments;
            }
        }

        public Department GetById(int id)
        {
            var query = string.Format($"Select * from Departments Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Department department = null;

                if (reader.Read())
                {
                    department = FillDepartment(reader);
                }

                return department;
            }
        }

        public void DeleteById(int id)
        {
            string query = "Delete From Departments Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@id"] = id;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Insert(Department department)
        {
            string query = "INSERT INTO Departments (Name, Address, Phone) VALUES (@Name, @Address, @Phone)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = department.Name;
                parameters["@Address"] = department.Address;
                parameters["@Phone"] = department.Phone;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Department department)
        {
            string query = "Update Departments Set Name = @Name, Address = @Address, Phone = @Phone Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Name"] = department.Name;
                parameters["@Address"] = department.Address;
                parameters["@Phone"] = department.Phone;
                parameters["@Id"] = department.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }


        public Department FillDepartment(SqlDataReader reader)
        {
            var department = new Department();

            department.Id = Convert.ToInt32(reader["Id"]);
            department.Name = reader["Name"].ToString();
            department.Phone = reader["Phone"].ToString();
            department.Address = reader["Address"].ToString();

            return department;
        }

    }
}