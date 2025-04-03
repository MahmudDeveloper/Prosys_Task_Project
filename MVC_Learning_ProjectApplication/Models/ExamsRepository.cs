using Microsoft.EntityFrameworkCore;
using MVC_Learning_ProjectApplication.Models;

public class ExamsRepository
{
    private readonly AppDbContext _context;

    public ExamsRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Exam> GetByDayAndDean(string deanName, DateTime date)
    {
        var query = _context.Exams
            .Include(e => e.Student)
            .Include(e => e.Class)
            .AsQueryable();

        query = query.Where(e => e.DateOfModificition.Date == date.Date);

        if (!string.IsNullOrWhiteSpace(deanName))
            query = query.Where(e => e.DeanName.ToLower() == deanName.ToLower());

        return query.ToList();
    }

public void Add(string deanName, int studentId,  int classId, 
        int courseWork, int midterm, int finalWork)
    {
        var exam = new Exam
        {
            DeanName = deanName,
            ClassId = classId,
            StudentId = studentId,
            CourseWork = courseWork,
            Midterm = midterm,
            Final_work = finalWork,
            DateOfModificition = DateTime.Now
        };

        _context.Exams.Add(exam);
        _context.SaveChanges();
    }

    public Exam? GetLastExamByStudentId(string deanName, int studentId)
    {
        return _context.Exams
            .Where(x => x.DeanName == deanName && x.StudentId == studentId)
            .OrderByDescending(x => x.DateOfModificition)
            .FirstOrDefault();
    }
}
