using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}