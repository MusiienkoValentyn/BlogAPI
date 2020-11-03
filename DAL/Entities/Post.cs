using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}