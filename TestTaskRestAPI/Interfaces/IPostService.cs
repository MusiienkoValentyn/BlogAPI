using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskRestAPI.Models;

namespace TestTaskRestAPI.Interfaces
{
    public interface IPostService
    {
        IEnumerable<DisplayPostModel> GetPosts();
        IEnumerable<PostAndCommentsModel> GetPostsAndComments();
        DisplayPostModel GetPost(int? id);
        void InsertPost(PostModel post);
        void UpdatePost(PostModel post);
        void DeletePost(int? id);
    }
}
