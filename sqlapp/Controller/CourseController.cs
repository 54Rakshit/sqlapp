using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sqlapp.Models;
using sqlapp.Services;
using System.Collections.Generic;

namespace sqlapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly IConfiguration _configuration;
        public CourseController(CourseService _svc, IConfiguration _config)
        {
            _courseService = _svc;
            _configuration = _config;
        }

        public IActionResult Index()
        {
            //IEnumerable<Course> _course_lst = _courseService.GetCourse();
            //IEnumerable<Course> _course_lst1 = _courseService.GetCourse1(_configuration.GetConnectionString("SQLConnection"));
            IEnumerable<Course> _course_lst = _courseService.GetCourses().GetAwaiter().GetResult();
            return View(_course_lst);
        }
    }
}
