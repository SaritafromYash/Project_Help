using Microsoft.AspNetCore.Mvc;
using MVC_EduHub.services;

namespace MVC_EduHub.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseservice;

        public CourseController(ICourseService courseservice)
        {
            _courseservice=courseservice;
        }
        public  IActionResult Index()
        {
           var data =_courseservice.GetAllCourses();
            return View(data);
        }
        public IActionResult MyCourses(int userid)
        {
             userid =Convert.ToInt32(TempData["EducatorId"]);
            var data = _courseservice.GetCoursesByUserId(userid);
            return View(data);
        }
    }
}
