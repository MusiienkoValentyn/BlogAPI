using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetPosts();
        IEnumerable<PostCommentDTO> GetPostsAndComments();
        PostDTO GetPost(int? id);
        void InsertPost(PostDTO post);
        void UpdatePost(PostDTO post);
        void DeletePost(int? id);
    }
}
