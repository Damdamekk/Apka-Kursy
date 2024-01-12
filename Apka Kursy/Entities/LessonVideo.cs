using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apka_Kursy.Entities
{
    public class LessonVideo
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public bool Active { get; set; }

        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}
