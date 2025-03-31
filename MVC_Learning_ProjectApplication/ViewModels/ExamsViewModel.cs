using System.ComponentModel.DataAnnotations;
using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.ViewModels
{
    public class ExamsViewModel
    {
        [Display(Name = "Dean Name:")]
        public string? DeanName { get; set; }
        [Display(Name = "Start Date:")]
        public DateTime StartDate {  get; set; } = DateTime.Today;
        [Display(Name = "End Date:")]
        public DateTime EndDate {  get; set; } = DateTime.Today;
        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
    }
}
