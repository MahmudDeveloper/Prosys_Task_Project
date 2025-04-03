using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Learning_ProjectApplication.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        public int ClassId { get; set; }

        public Class? Class { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }

        public int CourseWork { get; set; }

        public DateTime DateOfModificition { get; set; }

        public int Midterm { get; set; }

        public int Final_work { get; set; }

        public string DeanName { get; set; } = string.Empty;

    }
}
