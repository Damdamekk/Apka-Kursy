using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apka_Kursy.Entities
{
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AttachedMedia { get; set; }

        public Users Users { get; set; }

        [ForeignKey("CategoryId")]
        public ForumCategory ForumCategory { get; set; }
    }
}
