using System.Linq;
using System.Web.Mvc;
using Core;
using MvcApplication1.ViewModels;


namespace MvcApplication1.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            var vm = students.Select(x => new StudentViewModel() {StudentId = x.StudentId, StudentName = x.Name}).ToList();
            
            return View(vm);
        }

        public ActionResult Edit(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            var vm = new StudentViewModel {StudentId = student.StudentId, StudentName = student.Name};
             
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.UpdateStudentSp(studentViewModel.StudentId, studentViewModel.StudentName);
                ViewBag.Successful = true;
            }
            return View(studentViewModel);
        }
    }
}
