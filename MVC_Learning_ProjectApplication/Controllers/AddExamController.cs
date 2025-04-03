using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class AddExamController : Controller
    {
        private readonly AppDbContext _context;

        public AddExamController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var addExamViewModel = new AddExamViewModel
            {
                Classes = _context.Classes.ToList()
            };

            return View(addExamViewModel);
        }

        public IActionResult AddExamStudentPartial(int studentId)
        {
            var student = _context.Students
                .Include(s => s.ClassC)
                .FirstOrDefault(s => s.Id == studentId);

            var results = _context.Exams
                .Where(x => x.DeanName == "Dean" && x.StudentId == studentId)
                .OrderByDescending(x => x.DateOfModificition)
                .FirstOrDefault();

            var model = new AddExamViewModel
            {
                SelectedStudentId = studentId,
                CourseWork = results?.CourseWork ?? 0,
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
                var student = _context.Students.Find(addExamViewModel.SelectedStudentId);
                var classC = _context.Classes.Find(addExamViewModel.SelectedClassId);

                if (student != null && classC != null)
                {
                    var exam = new Exam
                    {
                        DeanName = "Dean",
                        StudentId = student.Id,
                        ClassId = classC.Id,
                        CourseWork = addExamViewModel.CourseWork ?? 0,
                        Midterm = addExamViewModel.Midterm ?? 0,
                        Final_work = addExamViewModel.FinalWork ?? 0,
                        DateOfModificition = DateTime.Now
                    };

                    _context.Exams.Add(exam);
                    _context.SaveChanges();
                }
            }

            addExamViewModel.Classes = _context.Classes.ToList();

            var refreshedStudent = _context.Students.Find(addExamViewModel.SelectedStudentId);
            addExamViewModel.SelectedClassId = refreshedStudent?.ClassId ?? 0;

            return View("Index", addExamViewModel);
        }
    }
}
