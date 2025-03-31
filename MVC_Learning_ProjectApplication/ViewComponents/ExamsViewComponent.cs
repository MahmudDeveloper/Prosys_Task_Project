using Microsoft.AspNetCore.Mvc;
using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.ViewComponents
{
    public class ExamsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = ExamsRepository.GetByDayAndDean(userName, DateTime.Now);
            return View(transactions);
        }
    }
}
