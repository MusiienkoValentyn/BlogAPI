using System.Collections.Generic;

namespace BLL.DTO
{
    public class PostCommentDTO
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public List<UserCommentDTO> Comments { get; set; }
    }
}
