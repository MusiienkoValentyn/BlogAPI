using BLL;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetComments();
        CommentDTO GetComment(int? id);
        void InsertComment(CommentDTO comment);
        void UpdateComment(CommentDTO comment);
        void DeleteComment(int? id);
        IEnumerable<UserCommentDTO> GetCommentsByPostId(int id);
    }
}
