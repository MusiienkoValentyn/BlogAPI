using System.Collections.Generic;
using TestTaskRestAPI.Models;

namespace TestTaskRestAPI.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentModel> GetComments();
        CommentModel GetComment(int? id);
        void InsertComment(CommentModel comment);
        void UpdateComment(CommentModel comment);
        void DeleteComment(int? id);
        IEnumerable<object> GetCommentsByPostId(int id);
    }
}
