using Microsoft.EntityFrameworkCore;

namespace MVC_Learning_ProjectApplication.Models
{
    public class StudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudentsByClassId(int classId)
        {
            return _context.Students
                .Where(s => s.ClassId == classId)
                .Include(s => s.ClassC)
                .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<Student> GetStudents(bool loadClass = false)
        {
            if (loadClass)
            {
                return _context.Students.Include(s => s.ClassC).ToList();
            }
            else
            {
                return _context.Students.ToList();
            }
        }

        public Student? GetStudentById(int id, bool loadClass = false)
        {
            if (loadClass)
            {
                return _context.Students
                    .Include(s => s.ClassC)
                    .FirstOrDefault(s => s.Id == id);
            }
            else
            {
                return _context.Students
                    .FirstOrDefault(s => s.Id == id);
            }
        }

        public void UpdateStudent(int id, Student student)
        {
            if (id != student.Id) return;

            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
 