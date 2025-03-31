using System.ComponentModel.DataAnnotations;

namespace MVC_Learning_ProjectApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Class")]
        public int? ClassId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Surname")]
        public string SurName { get; set; } = string.Empty;
        public Class? ClassC { get; set; }
    }
}
