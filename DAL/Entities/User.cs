using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        ICollection<Post> Posts { get; set; }
        ICollection<Comment> Comments { get; set; }
        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }

    }
}