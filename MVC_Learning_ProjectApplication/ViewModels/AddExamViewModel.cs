using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.ViewModels
{
    public class AddExamViewModel
    {
        public int SelectedClassId { get; set; }
        public IEnumerable<Class> Classes {  get; set; } = new List<Class>(); 
        public int SelectedStudentId { get; set; }
        public int? CourseWork {  get; set; }
        public int? Midterm {  get; set; }
        public int? FinalWork {  get; set; }
    }
}
