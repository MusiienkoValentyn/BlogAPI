using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
