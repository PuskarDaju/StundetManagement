// ReSharper disable once CheckNamespace

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public class Student
{
    [Key]
    public int student_id { get; set; }

    [Required]
    public string name { get; set; }

    [Range(1, 120)]
    public int age { get; set; }

    [Required, EmailAddress]
    public string email { get; set; }
}