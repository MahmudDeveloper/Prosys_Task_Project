using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class ExamsController : Controller
    {
        private readonly AppDbContext _context;

        public ExamsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ExamsViewModel examVM = new ExamsViewModel();
            return View(examVM);
        }

        [HttpPost]
        public IActionResult Search(ExamsViewModel model)
        {
            var query = _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Class)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.DeanName))
            {
                query = query.Where(e => e.DeanName.ToLower() == model.DeanName.ToLower());
            }

            if (model.StartDate != DateTime.MinValue && model.EndDate != DateTime.MinValue)
            {
                query = query.Where(e => e.DateOfModificition.Date >= model.StartDate.Date &&
                                         e.DateOfModificition.Date <= model.EndDate.Date);
            }

            model.Exams = query.ToList();
            return View("Index", model);
        }
    }
}
