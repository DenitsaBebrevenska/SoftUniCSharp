using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models;
public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.StudentNameMaxLength)]
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime Birthday { get; set; }

}
