using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["SomeName"] = "Hello";
            return View();
        }
        public ViewResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return Ok();
        }
        public IActionResult Index4(int id)
        {
            if (id <= 10)
            {
                return Ok();
            }
            return BadRequest();
        }
        public IActionResult Index5()
        {
            return NotFound();
        }
        public IActionResult Index6()
        {
            return Redirect("/home/index");
        }
        public IActionResult Index7()
        {
            return RedirectToAction("index2");
        }
        [HttpGet]
        public JsonResult Index8()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Tural",
                    Lastname="Eliyev",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Elvin",
                    Lastname="Camalzade",
                    CityId=2
                },
                new Employee
                {
                    Id=3,
                    Firstname="Omer",
                    Lastname="Cavanshirli",
                    CityId=3
                }
            };
            return Json(employees);
        }

        public JsonResult Index9(int id = -1)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Tural",
                    Lastname="Eliyev",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Elvin",
                    Lastname="Camalzade",
                    CityId=2
                },
                new Employee
                {
                    Id=3,
                    Firstname="Omer",
                    Lastname="Cavanshirli",
                    CityId=3
                }
            };
            if (id == -1)
            {
                return Json(employees);
            }
            var data = employees.FirstOrDefault(e => e.Id == id);
            return Json(data);
        }
        public JsonResult Index10(string name,int cityId)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Tural",
                    Lastname="Eliyev",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Elvin",
                    Lastname="Camalzade",
                    CityId=2
                },
                new Employee
                {
                    Id=3,
                    Firstname="Omer",
                    Lastname="Cavanshirli",
                    CityId=3
                }
            };
            var data = employees.Where(e => e.Firstname.Contains(name) || e.CityId == cityId);
            return Json(data);
        }
        public IActionResult Employees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Tural",
                    Lastname="Eliyev",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Elvin",
                    Lastname="Camalzade",
                    CityId=2
                },
                new Employee
                {
                    Id=3,
                    Firstname="Omer",
                    Lastname="Cavanshirli",
                    CityId=3
                }
            };

            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=1,
                    Name="Mike",
                    Score=12.1m
                },
                new Student
                {
                    Id=3,
                    Name="Leyla",
                    Score=99.99m
                }
            };

            //return View(employees);
            var vm = new EmployeStudentListViewModel
            {
                Employees = employees,
                Students = students
            };
            ViewBag.Info = TempData["SomeName"];
            ViewData["apple"] = new { Name = "Apple", Price = 100 };
            return View(vm);
        }
    }
}
