using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MVC_EduHub.Models;
using MVC_EduHub.services;
namespace MVC_EduHub.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialservice;

        public MaterialController(IMaterialService materialService )
        {
            _materialservice=materialService;
        }
        [HttpGet]
        public IActionResult AddMaterial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMaterial(int courseId, Material newmaterial)
        {   newmaterial.CourseId = courseId;
            if (ModelState.IsValid)
            {
                _materialservice.CreateMaterial(newmaterial);
                return RedirectToAction("MyCourses", "Course");
            }

            return View();
        }
    }
}
