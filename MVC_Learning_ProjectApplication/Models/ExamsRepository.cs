namespace MVC_Learning_ProjectApplication.Models
{
    public class ExamsRepository
    {
        private static List<Exam> _exams = new List<Exam>();

        public static IEnumerable<Exam> GetByDayAndDean(string CashierName, DateTime dateTime)
        {
            if (string.IsNullOrWhiteSpace(CashierName))
            {
                return _exams.Where(x=>x.DateOfModificition.Date==dateTime.Date);
            }
            else
            {
                return _exams.Where(x => x.DateOfModificition.Date == dateTime.Date && x.DeanName.ToLower() == CashierName.ToLower());
            }
        }
        public static IEnumerable<Exam> Search(string CashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(CashierName))
            {
                return _exams.Where(x=>x.DateOfModificition >=startDate.Date && x.DateOfModificition<= endDate.Date);
            }
            else
            {
                return _exams.Where(x => x.DateOfModificition >= startDate && x.DateOfModificition <= endDate.Date && x.DeanName ==CashierName);
            }
        }
        public static void Add(string cashierName, int studentId, string studentName,int courseWork,
            int midterm, int finalWork)
        {
            Exam exam = new Exam
            {
                DeanName = cashierName,
                StudentId = studentId,
                StudentName = studentName,
                CourseWork = courseWork,
                Midterm = midterm,
                Final_work = finalWork,
                DateOfModificition = DateTime.Now,
            };
            if (_exams.Any())
            {
                int maxId = _exams.Max(x => x.ExamId);
                exam.ExamId = maxId + 1;
            }
            else
            {
                exam.ExamId = 1;
            }
            _exams.Add(exam);
        }
        public static Exam? GetLastExamByStudentId(string cashierName, int studentId)
        {
            return _exams
                .Where(x => x.DeanName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)
                         && x.StudentId == studentId)
                .OrderByDescending(x => x.DateOfModificition)
                .FirstOrDefault();
        }

    }
}
