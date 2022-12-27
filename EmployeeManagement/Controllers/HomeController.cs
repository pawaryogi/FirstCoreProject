using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeInterface _EmpRepository;

        public HomeController(IEmployeeInterface emprepository)
        {
            _EmpRepository = emprepository;
        }

        public string Index()
        {
            return _EmpRepository.GetEmployee(1).Name.ToString();
        }

        public ViewResult Details()
        {
            Employee emp = _EmpRepository.GetEmployee(1);
            Employee emp2 = _EmpRepository.GetEmployee(2);
            ViewData["Emp"] = emp;
            ViewData["PageTitle"] = "Employee Details";
            return View(emp2);
        }

        public ViewResult DetailsWithViewBag()
        {
            Employee emp = _EmpRepository.GetEmployee(1);
            ViewBag.Emp = emp;
            ViewBag.PageTitle = "Employee Details (ViewBag)";
            return View();
        }
    }
}
