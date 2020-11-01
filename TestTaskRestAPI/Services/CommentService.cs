using System.Collections.Generic;
using System.Linq;
using TestTaskRestAPI.Interfaces;
using TestTaskRestAPI.Models;
using TestTaskRestAPI.Exception;

namespace TestTaskRestAPI.Services
{
    public class CommentService : ICommentService
    {
        public void DeleteComment(int? id)
        {
            if(id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var res = from comment in BlogModel.comments where comment.Id == id select comment; // Select comments with id like in param.

            BlogModel.comments.Remove(res.FirstOrDefault()); // Remove first comment from list.
        }

        public CommentModel GetComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var res = BlogModel.comments.Where(x => x.Id == id);

            if (res != null)
                return res.FirstOrDefault(); // If comment exists it is returned. 
            else
                throw new ValidationException("Comment not found", nameof(id));

        }

        public IEnumerable<CommentModel> GetComments()
        {
            return BlogModel.comments; // All comments from list returned.
        }

        public IEnumerable<object> GetCommentsByPostId(int id)
        {
            var res = from comment in BlogModel.comments
                      join post in BlogModel.posts on comment.IdPost equals post.Id
                      join user in BlogModel.users on comment.IdUser equals user.Id
                      where post.Id==id
                      select new {UserName=user.UserName, Comment=comment.Content }; // Select all comments for 1 post.                                                                                  

            return res.ToList(); // Return list with userNames and comments.
        }

        public void InsertComment(CommentModel comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));

            BlogModel.comments.Add(comment); // Add comment to list if comment exists.
        }

        public void UpdateComment(CommentModel comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));

            var element = GetComment(comment.Id); // Get comment by id.

            if(element!=null)
                element.Content = comment.Content; // Update content in comment.
            else
                throw new ValidationException("Comment not found", nameof(comment));
        }
    }
}
