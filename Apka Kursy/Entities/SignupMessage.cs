using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apka_Kursy.Entities
{
    public class SignupMessage
    {
        [Key]
        public int SignupMessageId { get; set; }

        [Required]
        public string Message { get; set; }

        public Course Course { get; set; }
    }
}
