using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestTaskRestAPI.Exception;
using TestTaskRestAPI.Interfaces;
using TestTaskRestAPI.Models;

namespace TestTaskRestAPI.Services
{
    public class PostService : IPostService
    {
        IWebHostEnvironment _environment;

        public PostService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public PostService()
        {
        }

        public void DeletePost(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var res = from post in BlogModel.posts where post.Id == id select post; // Select post by id.

            if (Directory.GetFiles(_environment.ContentRootPath + "\\Images\\").Contains(_environment.ContentRootPath +
                                                                   "\\Images\\" + res.FirstOrDefault().Id + ".jpg"))
            {
                File.Delete(_environment.ContentRootPath + "\\Images\\" + res.FirstOrDefault().Id + ".jpg"); // If image consists - it is deleted.
            }

            BlogModel.posts.Remove(res.FirstOrDefault()); // Post is removed from list.
        }

        public DisplayPostModel GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var res = (from post in BlogModel.posts
                       join user in BlogModel.users
                       on post.IdUser equals user.Id
                       where post.Id == id
                       select new DisplayPostModel
                       {
                           Id = post.Id,
                           Content = post.Content,
                           UserName = user.UserName,
                           Title = post.Title
                       }).FirstOrDefault(); // Get post information and return as DisplayPostModel.

            if (res != null)
            {
                if (Directory.GetFiles(_environment.ContentRootPath + "\\Images\\").Contains(_environment.ContentRootPath +
                    "\\Images\\" + res.Id + ".jpg"))
                {

                    res.Image = _environment.ContentRootPath + "\\Images\\" + res.Id + ".jpg"; // Add images link if it is exists.
                    return res;
                }
                return res;
            }
            else
                throw new ValidationException("Post not found", nameof(id));
        }

        public IEnumerable<DisplayPostModel> GetPosts()
        {
            List<DisplayPostModel> list = new List<DisplayPostModel>();

            foreach (var item in BlogModel.posts)
            {
                list.Add(GetPost(item.Id));
            }
            return list;
        }
        private List<DetailCommentModel> GetComments(DisplayPostModel model)
        {
            var res = from comment in BlogModel.comments
                      join post in BlogModel.posts on comment.IdPost equals post.Id
                      join user in BlogModel.users on comment.IdUser equals user.Id
                      where post.Id == model.Id
                      select new DetailCommentModel { UserName = user.UserName, Content = comment.Content }; // Get all comments from 1 post as DetailCommentModel.

            return res.ToList();
        }


        public IEnumerable<PostAndCommentsModel> GetPostsAndComments()
        {
            var res = GetPosts();
            List<PostAndCommentsModel> list = new List<PostAndCommentsModel>();
            PostAndCommentsModel postAndComments;
            DisplayPostModel postModel;

            foreach (var item in res)
            {
                postModel = GetPost(item.Id);

                postAndComments = (from post in BlogModel.posts
                                   join user in BlogModel.users on post.IdUser equals user.Id
                                   where post.Id == postModel.Id
                                   select new PostAndCommentsModel
                                   {
                                       UserName = user.UserName,
                                       Title = post.Title,
                                       Content = post.Content,
                                       Comments = GetComments(item)
                                   }
                                   ).FirstOrDefault(); // Get all posts and comment as PostAndCommentsModel.

                if (Directory.GetFiles(_environment.ContentRootPath + "\\Images\\").Contains(_environment.ContentRootPath +
                    "\\Images\\" + item.Id + ".jpg"))
                {

                    postAndComments.Image = _environment.ContentRootPath + "\\Images\\" + item.Id + ".jpg"; // Add images linh if it is exists.
                }
                else
                {
                    postAndComments.Image = null;
                }

                list.Add(postAndComments);
            }

            return list;
        }

        public void InsertPost(PostModel post)
        {
            if (post == null)
                throw new ValidationException("Argument is null", nameof(post));

            SaveImage(post); // Save image in folder.
            BlogModel.posts.Add(post);
        }

        public async Task<string> SaveImage(PostModel post)
        {
            try
            {
                if (post.Image != null)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Images\\"); // If folder is mot consist - create it;
                    }

                    using (FileStream fileStream = File.Create(_environment.ContentRootPath + "\\Images\\" + post.Id + ".jpg"))
                    {
                        post.Image.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Image" + post.Id;
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public void UpdatePost(PostModel post)
        {
            if (post == null)
                throw new ValidationException("Argument is null", nameof(post));

            var element = (from posts in BlogModel.posts where posts.Id == post.Id select posts).FirstOrDefault(); // Get post by id.

            if (element != null)
            {
                element.Content = post.Content;
                element.Title = post.Title;

                if (element.Image != null)
                {
                    SaveImage(post);
                }
                else
                {
                    File.Delete(_environment.ContentRootPath + "\\Images\\" + post.Id + ".jpg"); // Delete image if it is empty in updated post.
                }
            }
            else
                throw new ValidationException("Comment not found", nameof(post));
        }
    }
}
