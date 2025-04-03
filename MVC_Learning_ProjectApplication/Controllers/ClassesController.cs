using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class ClassesController : Controller
    {
        private readonly AppDbContext _context;

        public ClassesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var classes = _context.Classes.ToList();
            return View(classes);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            if (!id.HasValue) return NotFound();

            var classC = _context.Classes.Find(id.Value);
            if (classC == null) return NotFound();

            return View(classC);
        }

        [HttpPost]
        public IActionResult Edit(Class? classC)
        {
            if (classC == null) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Classes.Update(classC);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(classC);
        }

        public IActionResult AddClass()
        {
            ViewBag.Action = "AddClass";
            return View();
        }

        [HttpPost]
        public IActionResult AddClass(Class classC)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Add(classC);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(classC);
        }

        public IActionResult DeleteClass(int id)
        {
            var classToDelete = _context.Classes.Find(id);
            if (classToDelete != null)
            {
                _context.Classes.Remove(classToDelete);
                _context.SaveChanges(); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
