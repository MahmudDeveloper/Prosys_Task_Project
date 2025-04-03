using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students
                .Include(s => s.ClassC)
                .ToList();

            return View(students);
        }

        public IActionResult AddStudent()
        {
            ViewBag.Action = "AddStudent";

            var studentViewModel = new StudentViewModel
            {
                Classes = _context.Classes.ToList()
            };

            return View(studentViewModel);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(viewModel.Student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "AddStudent";
            viewModel.Classes = _context.Classes.ToList();
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            var studentViewModel = new StudentViewModel
            {
                Student = student,
                Classes = _context.Classes.ToList()
            };

            return View(studentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(viewModel.Student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Edit";
            viewModel.Classes = _context.Classes.ToList();
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult StudentsByClassPartial(int classId)
        {
            var students = _context.Students
                .Where(s => s.ClassId == classId)
                .ToList();

            return PartialView("_Students", students);
        }
    }
}
