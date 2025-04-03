using Microsoft.EntityFrameworkCore;

namespace MVC_Learning_ProjectApplication.Models
{
    public class ClassesRepository
    {
        private readonly AppDbContext _context;

        public ClassesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Class> GetClasses()
        {
            return _context.Classes.ToList();
        }

        public Class? GetClassById(int id)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == id);
        }

        public void AddClass(Class classC)
        {
            _context.Classes.Add(classC);
            _context.SaveChanges();
        }

        public void UpdateClass(int id, Class classC)
        {
            if (id != classC.Id) return;

            var classToUpdate = _context.Classes.FirstOrDefault(c => c.Id == id);
            if (classToUpdate != null)
            {
                classToUpdate.Name = classC.Name;
                classToUpdate.Description = classC.Description;
                _context.SaveChanges();
            }
        }

        public void DeleteClass(int id)
        {
            var classToDelete = _context.Classes.FirstOrDefault(c => c.Id == id);
            if (classToDelete != null)
            {
                _context.Classes.Remove(classToDelete);
                _context.SaveChanges();
            }
        }
    }
}
