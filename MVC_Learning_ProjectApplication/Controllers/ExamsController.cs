using Microsoft.AspNetCore.Mvc;
using MVC_Learning_ProjectApplication.Models;
using MVC_Learning_ProjectApplication.ViewModels;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult Index()
        {
            ExamsViewModel examVM = new ExamsViewModel();
            return View(examVM);
        }

        [HttpPost]
        public IActionResult Search(ExamsViewModel model)
        {
            model.Exams = ExamsRepository.Search(model.DeanName??string.Empty, model.StartDate, model.EndDate);
            return View("Index", model);
        }
    }
}
