namespace MVC_Learning_ProjectApplication.Models
{
    public class ClassesRepository
    {
        private static List<Class> _classes = new List<Class>()
        {
            new Class {Id = 1, Name ="Mat", Description="Mathematics" },
            new Class {Id = 2, Name ="Phy", Description="Physics" },
            new Class {Id = 3, Name ="Bio", Description="Biology" }
        };

        private static int _nextClassId = 4;

        public static void AddClass(Class classC)
        {
            classC.Id = _nextClassId++;
            _classes.Add(classC);
        }

        public static List<Class> GetClasses() => _classes;
        
        public static Class? GetClassById(int id)
        {
            var classC = _classes.FirstOrDefault(c => c.Id == id);
            if (classC != null)
            {
                return new Class
                {
                    Id = classC.Id,
                    Name = classC.Name,
                    Description = classC.Description
                };
            }
           return null;
        }
        public static void UpdateClass(int id, Class classC)
        {
            if (id != classC.Id) return;
            var classToUpdate = _classes.FirstOrDefault(c => c.Id == id);
            if (classToUpdate != null)
            {
                classToUpdate.Name = classC.Name;
                classToUpdate.Description = classC.Description;
            }
        }
        public static void DeleteClass(int id)
        {
            var classToDelete = _classes.FirstOrDefault(c=> c.Id==id);
            if (classToDelete != null)
            {
                _classes.Remove(classToDelete);
            }
        }
    }
}