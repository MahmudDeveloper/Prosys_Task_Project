using System.ComponentModel.DataAnnotations;

namespace MVC_Learning_ProjectApplication.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
