using System.ComponentModel.DataAnnotations;
using Apka_Kursy.Entities;

namespace Apka_Kursy.Models;

public class CourseModel
{
    public int SignupMessageId { get; set; }

    [Required]
    public int CourseCategoryId { get; set; }

    [Required]
    [MaxLength(250)]
    public string Title { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<Signup> Signups { get; set; }

    public ICollection<Lesson> Lessons { get; set; }

    public SignupMessage SignupMessage { get; set; }

    public CoursesCategory CoursesCategory { get; set; }

    public ICollection<Payment> Payments { get; set; }
}