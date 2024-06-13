using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sqlapp.Models;
using sqlapp.Services;
using System.Collections.Generic;

namespace sqlapp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CourseService _courseService;
        private readonly EmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        public EmployeeController(EmployeeService _svc, IConfiguration _config)
        {
            _employeeService = _svc;
            _configuration = _config;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> _employee_lst = _employeeService.GetEmployees().GetAwaiter().GetResult();
            return View(_employee_lst);
        }
    }
}
