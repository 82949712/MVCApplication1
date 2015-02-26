using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Web.Core;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudent()
        {
            var student = _studentRepository.GetStudentCourses(1).FirstOrDefault();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudents()
        {
            var student = _studentRepository.GetStudents();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

    }
}
