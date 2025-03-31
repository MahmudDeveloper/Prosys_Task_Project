using Microsoft.AspNetCore.Mvc;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var _students = StudentsRepository.GetStudents(loadClass:true);
            foreach (var student in _students)
            {
                if (student.ClassId.HasValue)
                {
                    var classC = ClassesRepository.GetClassById(student.ClassId.Value);
                    student.ClassC = classC;
                }
            }
            return View(_students);
        }
        public IActionResult AddStudent()
        {
            ViewBag.Action = "AddStudent";
            var studentViewModel = new StudentViewModel
            {
                Classes = ClassesRepository.GetClasses()
            };

            return View(studentViewModel);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                StudentsRepository.AddStudent(viewModel.Student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "AddStudent";
            viewModel.Classes = ClassesRepository.GetClasses();
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var studentViewModel = new StudentViewModel
            {
                Student = StudentsRepository.GetStudentById(id, true)?? new Student(),
                Classes = ClassesRepository.GetClasses()
            };
            return View(studentViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                StudentsRepository.UpdateStudent(viewModel.Student.Id, viewModel.Student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "Edit";
            viewModel.Classes = ClassesRepository.GetClasses();
            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
            StudentsRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentsByClassPartial(int classId)
        {
            var students = StudentsRepository.GetStudentsByClassId(classId);
            return PartialView("_Students", students);
        }
    }
}