using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sqlapp.Models;
using sqlapp.Services;
using System.Collections.Generic;

namespace sqlapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly CourseService _courseService;
        private readonly EmployeeService _employeeService;
        private readonly ProductService _productService;
        private readonly IConfiguration _configuration;
        public ProductController(ProductService _productSvc, IConfiguration _config)
        {
            _productService = _productSvc;
            _configuration = _config;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> _product_lst = _productService.GetProducts(_configuration.GetConnectionString("SQLConnection"));
            return View(_product_lst);
        }
    }
}
