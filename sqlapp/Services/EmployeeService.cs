using Microsoft.Data.SqlClient;
using sqlapp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class EmployeeService
    {
    
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            string function_url = "https://coursedbfunction.azurewebsites.net/api/GetCourses?code=lWTW3BBfpz2ciaIslFrQ9d3Ml2ooHWjnvlJ0pHSoSyZbOzmJhOVTXw%3D%3D";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage _response = await client.GetAsync(function_url);
                string _content = await _response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Employee>>(_content);
            }
        }
    }
}
