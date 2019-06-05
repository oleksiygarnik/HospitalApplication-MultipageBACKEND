using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class EmployeeDAO : IDataAccessObject<Employee>
    {
        private static EmployeeDAO instance = null;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeDAO();

                return instance;
            }
        }

        private EmployeeDAO() { }


        public Employee GetById(int id) // check on employee need
        {
            var query = string.Format($"Select * from Users Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                Employee employee = null;

                if (reader.Read())
                {
                    employee = FillEmployee(reader);
                }

                return employee;
            }
        }


        public IEnumerable<Employee> GetAll()
        {
            string query = "Select * from Users where Discriminator = 'Employee'"; 

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<Employee> employees = new List<Employee>();

                while (reader.Read())
                {
                    var employee = FillEmployee(reader);

                    if (employee != null)
                    {
                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }


        public void DeleteById(int id)
        {
            string query = "Delete From Users Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@id"] = id;

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Insert(Employee employee)
        {
            string query = "INSERT INTO Users (Firstname, Surname, Patronymic, Email, Password, RoleId, Discriminator)" +
                                     " VALUES (@Firstname, @Surname, @Patronymic, @Email, @Password, @RoleId, @Discriminator)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Firstname"] = employee.Firstname;
                parameters["@Surname"] = employee.Surname;
                parameters["@Patronymic"] = employee.Patronymic;
                parameters["@Email"] = employee.Email;
                parameters["@Password"] = employee.Password;
                parameters["@RoleId"] = employee.RoleId;
                parameters["@Discriminator"] = "Employee";

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(Employee employee)
        {
            string query = "Update Roles Set Firstname = @Firstname, Surname = @Surname, Patronymic = @Patronymic," +
                                           " Email = @Email, Password = @Password, RoleId = @RoleId Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Firstname"] = employee.Firstname;
                parameters["@Surname"] = employee.Surname;
                parameters["@Patronymic"] = employee.Patronymic;
                parameters["@Email"] = employee.Email;
                parameters["@Password"] = employee.Password;
                parameters["@RoleId"] = employee.RoleId;
                parameters["@Id"] = employee.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }


        public Employee FillEmployee(SqlDataReader reader)
        {
            var employee = new Employee();

            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.Firstname = reader["Firstname"].ToString();
            employee.Surname = reader["Surname"].ToString();
            employee.Patronymic = reader["Patronymic"].ToString();
            employee.Email = reader["Email"].ToString();
            employee.Password = reader["Password"].ToString();
            employee.RoleId = Convert.ToInt32(reader["RoleId"]);

            return employee;
        }

    }
}