using System.ComponentModel.DataAnnotations;

namespace DAL.Context
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int IdPost { get; set; }
        public Post Post { get; set; }

        [Required]
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}