using Microsoft.Data.SqlClient;
using sqlapp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class CourseService
    {
        public static string db_source = "rkserver5496.database.windows.net";
        public static string db_user = "rakshit";
        public static string db_password = "Humtum@42";
        public static string db_database = "appdb";

        private SqlConnection GetConnection(string _connection_string)
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(_connection_string);

        }

        //public IEnumerable<Course> GetCourse()
        //{
        //    List<Course> _list = new List<Course>();
        //    string _statement = "SELECT CourseID, CourseName, Rating FROM Course";
        //    SqlConnection _connection = GetConnection(_connection_string);
        //    _connection.Open();
        //    SqlCommand _sqlCommand = new SqlCommand(_statement, _connection);
        //    using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
        //    {
        //        while (_reader.Read())
        //        {
        //            Course _course = new Course()
        //            {
        //                CourseID = _reader.GetInt32(0),
        //                CourseName = _reader.GetString(1),
        //                Rating = _reader.GetDecimal(2)
        //            };
        //            _list.Add(_course);
        //        }
        //    }
        //    _connection.Close();
        //    return _list;

        //}

        //public IEnumerable<Course> GetCourse1(string _connection_string)
        //{
        //    List<Course> _list = new List<Course>();
        //    string _statement = "SELECT CourseID, CourseName, Rating FROM Course";
        //    SqlConnection _connection = GetConnection(_connection_string);
        //    _connection.Open();
        //    SqlCommand _sqlCommand = new SqlCommand(_statement, _connection);
        //    using (SqlDataReader _reader = _sqlCommand.ExecuteReader())
        //    {
        //        while (_reader.Read())
        //        {
        //            Course _course = new Course()
        //            {
        //                CourseID = _reader.GetInt32(0),
        //                CourseName = _reader.GetString(1),
        //                Rating = _reader.GetDecimal(2)
        //            };
        //            _list.Add(_course);
        //        }
        //    }
        //    _connection.Close();
        //    return _list;

        //}


        public async Task<IEnumerable<Course>> GetCourses()
        {
            string function_url = "https://coursedbfunction.azurewebsites.net/api/GetCourses?code=lWTW3BBfpz2ciaIslFrQ9d3Ml2ooHWjnvlJ0pHSoSyZbOzmJhOVTXw%3D%3D";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage _response = await client.GetAsync(function_url);
                string _content = await _response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Course>>(_content);
            }
        }






    }
}
