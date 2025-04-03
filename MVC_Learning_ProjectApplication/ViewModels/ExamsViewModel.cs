using MVC_Learning_ProjectApplication.Models;

public class ExamsViewModel
{
    public string? DeanName { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Today;
    public DateTime EndDate { get; set; } = DateTime.Today;
    public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
}
