using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PostCommentDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public List<UserCommentDTO> Comments { get; set; }
    }
}
