using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; }
    }
}
