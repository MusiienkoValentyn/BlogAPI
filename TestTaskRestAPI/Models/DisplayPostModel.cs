using System.ComponentModel.DataAnnotations;

namespace TestTaskRestAPI.Models
{
    public class DisplayPostModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
