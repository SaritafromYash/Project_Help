using Microsoft.AspNetCore.Mvc;
using MVC_EduHub.Models;
using MVC_EduHub.services;

namespace MVC_EduHub.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUserService _userservice;

        public StudentController(IUserService userService)
        {
            _userservice = userService;
        }
        public IActionResult StudentIndex()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentLogIn(LoginModel login)
        {
            var data = _userservice.GetStudent(login.Username, login.Password);

            if (data.UserRole == "student")
            {
                TempData["student"] = data.UserName;
                return RedirectToAction("StudentIndex");
            }
            return View(data);
        }

  
        public ActionResult StudentLogOut()
        {              
            return RedirectToAction("Index", "Home");
            
        }
    }
}
