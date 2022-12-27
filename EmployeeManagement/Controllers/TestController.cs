using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class TestController : Controller
    {
        private IEmployeeInterface _EmpRepository;

        public TestController(IEmployeeInterface emprepository)
        {
            _EmpRepository = emprepository;
        }

        public string Index()
        {
            return _EmpRepository.GetEmployee(2).Name.ToString();
        }


    }
}
