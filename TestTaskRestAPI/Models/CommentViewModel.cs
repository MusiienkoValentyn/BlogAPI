using System.ComponentModel.DataAnnotations;

namespace TestTaskRestAPI.Models
{
    public class CommentViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
