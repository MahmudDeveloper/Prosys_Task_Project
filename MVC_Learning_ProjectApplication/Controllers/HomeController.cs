using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Learning_ProjectApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
