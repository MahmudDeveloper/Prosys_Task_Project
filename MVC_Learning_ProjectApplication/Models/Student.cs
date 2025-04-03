using System.ComponentModel.DataAnnotations;
using MVC_Learning_ProjectApplication.Models;
using static Azure.Core.HttpHeader;

public class Student
{
    public int Id { get; set; }

    [Display(Name = "Class")]
    [Required]
    public int? ClassId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string SurName { get; set; } = string.Empty;

    public Class? ClassC { get; set; }
}
