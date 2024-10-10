
using EduHub_Project.repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub.Models;
using MVC_EduHub.services;

namespace MVC_EduHub.Controllers
{
    public class UserController : Controller
    {
        // private readonly AppDbContext _context;
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EducatorIndex()
        {
            TempData.Keep();
            return View();
        }



        [HttpGet]
        public IActionResult AddUser()
        {
            List<SelectListItem> userroles = new List<SelectListItem>()
           {new SelectListItem { Text = "Educator", Value = "Educator" },
            new SelectListItem{ Text="Student",Value="student"},
              };
            ViewBag.role = userroles;
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User newuser)
        {
            _userservice.CreateUser(newuser);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EductorLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EductorLogin(LoginModel login)
        {
            var data = _userservice.GetEducator(login.Username, login.Password);


            if (data.UserRole == "Educator")
            {
                TempData["Educator"] = data.UserName;
                TempData["EducatorId"]=data.UserId;
                TempData.Keep();
               
              
                return RedirectToAction("EducatorIndex");
            }
            return View();
        }


        public ActionResult EducatorLogOut()
        {
            return RedirectToAction("Index", "Home");


        }
    }
}