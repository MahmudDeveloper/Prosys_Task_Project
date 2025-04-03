using Microsoft.AspNetCore.Mvc;

public class ExamsViewComponent : ViewComponent
{
    private readonly ExamsRepository _repo;

    public ExamsViewComponent(ExamsRepository repo)
    {
        _repo = repo;
    }

    public IViewComponentResult Invoke(string deanName)
    {
        var exams = _repo.GetByDayAndDean(deanName, DateTime.Now);
        return View(exams);
    }
}
