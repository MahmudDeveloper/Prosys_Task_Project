using Microsoft.AspNetCore.Mvc;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class AddExamController : Controller
    {
        public IActionResult Index()
        {
            AddExamViewModel addExamViewModel = new AddExamViewModel()
            {
                Classes = ClassesRepository.GetClasses()
            };
            return View(addExamViewModel);
        }
        public IActionResult AddExamStudentPartial(int studentId)
        {
            var student = StudentsRepository.GetStudentById(studentId);
            var results = ExamsRepository.GetLastExamByStudentId("Dean",studentId);

            var model = new AddExamViewModel
            {
                SelectedStudentId = studentId,
                CourseWork = results?.CourseWork?? 0,
                Midterm = results?.Midterm ?? 0,
                FinalWork = results?.Final_work ?? 0
            };

            ViewBag.Student = student;
            return PartialView("_IntroStudent", model);
        }

        [HttpPost]
        public IActionResult AddExam(AddExamViewModel addExamViewModel)
        {
            if (ModelState.IsValid)
            {
                var studentForStore = StudentsRepository.GetStudentById(addExamViewModel.SelectedStudentId);
                if (studentForStore != null)
                {
                    ExamsRepository.Add(
                        "Dean",
                        addExamViewModel.SelectedStudentId,
                        studentForStore.Name,
                        addExamViewModel.CourseWork ?? 0,
                        addExamViewModel.Midterm ?? 0,
                        addExamViewModel.FinalWork ?? 0
                        );
                }
            }
            addExamViewModel.Classes = ClassesRepository.GetClasses();
            var student = StudentsRepository.GetStudentById(addExamViewModel.SelectedStudentId, true);
            addExamViewModel.SelectedClassId = (student?.ClassId==null)?0:student.ClassId.Value;
            return View("Index", addExamViewModel);
        }
    }
}