using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\hospdb.mdf';Integrated Security=True";
namespace HospitalApplicationFirst.DAO
{
    public class DbConnector : IDisposable
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public SqlConnection _connection;

        public DbConnector()
        {
            _connection = new SqlConnection(connectionString);

            _connection.Open();
        }


        public int ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            SqlCommand command = new SqlCommand(query, _connection);
            if (parameters != null)
            {
                foreach (var KeyValue in parameters)
                {
                    command.Parameters.AddWithValue(KeyValue.Key, KeyValue.Value);
                }
            }
            var count = command.ExecuteNonQuery();

            return count;
        }


        public object ExecuteScalar(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);
            return command.ExecuteScalar();
        }


        public SqlDataReader ExecuteReader(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);
            return command.ExecuteReader();
        }


        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
    }
}