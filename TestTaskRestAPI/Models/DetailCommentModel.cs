using System.ComponentModel.DataAnnotations;

namespace TestTaskRestAPI.Models
{
    public class DetailCommentModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
