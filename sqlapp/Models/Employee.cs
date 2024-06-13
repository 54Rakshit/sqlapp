using System;

namespace sqlapp.Models
{
    public class Employee
    {
        public int employee_id {  get; set; }
        public string first_name {  get; set; }
        public string last_name { get; set;}
        public string email { get; set; }
        public DateTime hire_date { get; set; }
    }
}
