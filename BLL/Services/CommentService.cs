using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using BLL.Interfaces;
using DAL.Entities;
using BLL.Exception;

namespace BLL.Services
{
    public class CommentService : BaseService<CommentDTO,Comment>, ICommentService
    {

        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeleteComment(int? id)
        {
            if(id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Comment.Delete(id.Value);
            UnitOfWork.Save();
        }

        public CommentDTO GetComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var comment = UnitOfWork.Comment.Get(id.Value);

            if (comment == null)
                throw new ValidationException("Place not found", nameof(comment));

            return ToBllEntity(comment);
        }

        public IEnumerable<CommentDTO> GetComments()
        {
            return ToBllEntity(UnitOfWork.Comment.GetAll());
        }

        public IEnumerable<UserCommentDTO> GetCommentsByPostId(int id)
        {
            var res = from comment in UnitOfWork.Comment.GetAll()
                      join post in UnitOfWork.Post.GetAll() on comment.PostId equals post.Id
                      join user in UnitOfWork.User.GetAll() on comment.UserId equals user.Id
                      where post.Id==id
                      select new UserCommentDTO{UserName=user.UserName, Comment=comment.Content }; // Select all comments for 1 post.                                                                                  

            return res.ToList(); // Return list with userNames and comments.
        }

        public void InsertComment(CommentDTO comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));

            Comment commentEntity = ToDalEntity(comment);
            UnitOfWork.Comment.Create(commentEntity);
            UnitOfWork.Save();
        }

        public void UpdateComment(CommentDTO comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));

            Comment commentEntity = ToDalEntity(comment);
            UnitOfWork.Comment.Update(commentEntity);
            UnitOfWork.Save();
        }
    }
}
