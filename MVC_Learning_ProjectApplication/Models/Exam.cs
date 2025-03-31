namespace MVC_Learning_ProjectApplication.Models
{
    public class Exam
    {
        public int ExamId { get; set; }//
        public int StudentId { get; set; }//
        public string StudentName { get; set; } = "";//
        public int CourseWork { get; set; }//
        public DateTime DateOfModificition { get; set; }
        public int Midterm { get; set; }//
        public int Final_work { get; set; }//
        public string DeanName { get; set; } = "";//
    }
}
