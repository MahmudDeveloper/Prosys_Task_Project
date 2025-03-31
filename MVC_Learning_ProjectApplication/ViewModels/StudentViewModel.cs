using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Learning_ProjectApplication.Models;

namespace MVC_Learning_ProjectApplication.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; } = new Student();
        public List<Class> Classes { get; set; } = new List<Class>();
    }
}
