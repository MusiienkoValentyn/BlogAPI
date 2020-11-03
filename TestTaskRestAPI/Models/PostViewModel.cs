using Microsoft.AspNetCore.Http;

namespace TestTaskRestAPI
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public IFormFile ImageForm { get; set; }
    }
}