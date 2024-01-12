using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apka_Kursy.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string PriceString { get; set; }

        [Required]
        public bool HasHomework { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [InverseProperty("Lesson")]
        public LessonVideo LessonVideo { get; set; }
    }
}
