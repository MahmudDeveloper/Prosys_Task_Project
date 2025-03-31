namespace MVC_Learning_ProjectApplication.Models
{
    public class StudentsRepository
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, ClassId = 1, Name = "Jone", SurName="Jones" },
            new Student { Id = 2, ClassId = 1, Name = "Khabib", SurName="Nurmagammedov" },
            new Student { Id = 3, ClassId = 2, Name = "Islam", SurName="Makhachev" },
            new Student { Id = 4, ClassId = 2, Name = "Umar", SurName = "Nurmagomedov" },
            new Student { Id = 5, ClassId = 3, Name = "Magomed", SurName = "Ankalaev" }
        };
        public static List<Student> GetStudentsByClassId(int classId)
        {
            var students = _students.Where(p =>p.ClassId==classId);
            if (students != null)
            {
                return students.ToList();
            }
            else
            {
                return new List<Student>();
            }
        }
        public static void AddStudent(Student student)
        {
            if (_students == null || !_students.Any())
            {
                student.Id = 1;
            }
            else
            {
                var maxIdStud = _students.Max(c => c.Id);
                student.Id = maxIdStud + 1;
            }
            _students?.Add(student);
        }

        public static List<Student> GetStudents(bool loadClass = false)
        {
            if(!loadClass)
            {
                if (_students.Count > 0 && _students != null)
                {
                    foreach (var student in _students)
                    {
                        if (student.ClassId.HasValue)
                        {
                            student.ClassC = ClassesRepository.GetClassById(student.ClassId.Value);
                        }
                    }
                }
            }
            return _students ??new List<Student>();
        }

        public static Student? GetStudentById(int Id, bool loadClass=false)
        {
            var student = _students.FirstOrDefault(x => x.Id == Id);
            if (student != null)
            {
                var stud = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    SurName = student.SurName,
                    ClassId = student.ClassId
                };
                if(loadClass == true && stud.ClassId.HasValue)
                {
                    stud.ClassC = ClassesRepository.GetClassById(stud.ClassId.Value);
                }
                return stud;
            }
            else
            {
                return null;
            }
        }

        public static void UpdateStudent(int Id, Student student)
        {
            if (Id != student.Id) return;

            var studentToUpdate = _students.FirstOrDefault(x => x.Id == Id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.SurName = student.SurName;
                studentToUpdate.ClassId = student.ClassId;
            }
        }

        public static void DeleteStudent(int Id)
        {
            var student = _students.FirstOrDefault(x => x.Id == Id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
