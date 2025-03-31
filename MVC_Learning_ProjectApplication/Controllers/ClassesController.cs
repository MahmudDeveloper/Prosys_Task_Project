using Microsoft.AspNetCore.Mvc;
using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            var classes = ClassesRepository.GetClasses();
            if (classes != null && classes.Count()>0)
            {
                return View(classes);
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var classC = ClassesRepository.GetClassById(id.HasValue?id.Value:0);
            return View(classC);
        }
        [HttpPost]
        public IActionResult Edit(Class? classC)
        {
            if (classC == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                ClassesRepository.UpdateClass(classC.Id, classC);
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
                ClassesRepository.AddClass(classC);
                return RedirectToAction(nameof(Index));
            }
            return View(classC);
        }
        public ActionResult DeleteClass(int id)
        {
            ClassesRepository.DeleteClass(id);
            return RedirectToAction(nameof(Index));
        }
    }
}