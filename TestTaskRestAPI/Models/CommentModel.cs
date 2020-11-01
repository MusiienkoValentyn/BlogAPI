using System.ComponentModel.DataAnnotations;

namespace TestTaskRestAPI.Models
{
    public class CommentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdPost { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
