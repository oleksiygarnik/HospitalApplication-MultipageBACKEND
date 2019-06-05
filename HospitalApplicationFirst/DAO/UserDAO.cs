using HospitalApplicationFirst.DAO.Interfaces;
using HospitalApplicationFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalApplicationFirst.DAO
{
    public class UserDAO : IDataAccessObject<User>
    {
        private static UserDAO instance = null;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserDAO();

                return instance;
            }
        }

        private UserDAO() { }


        public User GetById(int id)
        {
            var query = string.Format($"Select * from Users Where Id = {id}");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                User user = null;

                if (reader.Read())
                {
                    user = FillUser(reader);
                }

                return user;
            }
        }

        public User GetUserByEmail(string email)
        {
            var query = string.Format($"Select * from Users Where Email = '{email}'");

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                User user = null;

                if (reader.Read())
                {
                    user = FillUser(reader);
                }

                return user;
            }
        }


        public IEnumerable<User> GetAll()
        {
            string query = "Select * from Users Where Discriminator = 'User'";

            using (DbConnector dbConnector = new DbConnector())
            {
                var reader = dbConnector.ExecuteReader(query);

                List<User> users = new List<User>();

                while (reader.Read())
                {
                    var user = FillUser(reader);

                    if (user != null)
                    {
                        users.Add(user);
                    }
                }

                return users;
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

        public void Insert(User user)
        {
            string query = "INSERT INTO Users (Firstname, Surname, Patronymic, Email, Password, RoleId, Discriminator)" +
                                     " VALUES (@Firstname, @Surname, @Patronymic, @Email, @Password, @RoleId, @Discriminator)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Firstname"] = user.Firstname;
                parameters["@Surname"] = user.Surname;
                parameters["@Patronymic"] = user.Patronymic;
                parameters["@Email"] = user.Email;
                parameters["@Password"] = user.Password;
                parameters["@RoleId"] = user.RoleId;
                parameters["@Discriminator"] = "User";

                dbConnector.ExecuteQuery(query, parameters);
            }
        }

        public void Update(User user)
        {
            string query = "Update Roles Set Firstname = @Firstname, Surname = @Surname, Patronymic = @Patronymic," +
                                           " Email = @Email, Password = @Password, RoleId = @RoleId Where Id = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            using (DbConnector dbConnector = new DbConnector())
            {
                parameters["@Firstname"] = user.Firstname;
                parameters["@Surname"] = user.Surname;
                parameters["@Patronymic"] = user.Patronymic;
                parameters["@Email"] = user.Email;
                parameters["@Password"] = user.Password;
                parameters["@RoleId"] = user.RoleId;
                parameters["@Id"] = user.Id;

                dbConnector.ExecuteQuery(query, parameters);
            }

        }


        public User FillUser(SqlDataReader reader)
        {
            var user = new User();

            user.Id = Convert.ToInt32(reader["Id"]);
            user.Firstname = reader["Firstname"].ToString();
            user.Surname = reader["Surname"].ToString();
            user.Patronymic = reader["Patronymic"].ToString();
            user.Email = reader["Email"].ToString();
            user.Password = reader["Password"].ToString();
            user.RoleId = Convert.ToInt32(reader["RoleId"]);

            return user;
        }
    }
}