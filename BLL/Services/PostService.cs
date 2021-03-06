﻿using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Exception;
using DAL.Entities;
using DAL.Interfaces;
using BLL.DTO;

namespace BLL.Services
{
    public class PostService : BaseService<PostDTO, Post>, IPostService
    {

        public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePost(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Post.Delete(id.Value);
            UnitOfWork.Save();
        }

        public PostDTO GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            var post = UnitOfWork.Post.Get(id.Value);

            if (post == null)
                throw new ValidationException("Place not found", nameof(post));

            return ToBllEntity(post);
        }

        public IEnumerable<PostDTO> GetPosts()
        {
            return ToBllEntity(UnitOfWork.Post.GetAll());
        }
        private List<UserCommentDTO> GetComments(PostDTO postModel)
        {
            var res = from comment in UnitOfWork.Comment.GetAll()
                      join post in UnitOfWork.Post.GetAll() on comment.PostId equals post.Id
                      join user in UnitOfWork.User.GetAll() on comment.UserId equals user.Id
                      where post.Id == postModel.Id
                      select new UserCommentDTO { UserName = user.UserName, Comment = comment.Content }; // Get all comments from 1 post as DetailCommentModel.

            return res.ToList();
        }


        public IEnumerable<PostCommentDTO> GetPostsAndComments()
        {
            var res = GetPosts();
            List<PostCommentDTO> list = new List<PostCommentDTO>();
            PostCommentDTO postAndComments;
            PostDTO postModel;

            foreach (var item in res)
            {
                postModel = GetPost(item.Id);

                postAndComments = (from post in UnitOfWork.Post.GetAll()
                                   join user in UnitOfWork.User.GetAll() on post.UserId equals user.Id
                                   where post.Id == postModel.Id
                                   select new PostCommentDTO
                                   {
                                       UserName = user.UserName,
                                       Title = post.Title,
                                       Content = post.Content,
                                       Comments = GetComments(item),
                                       Image = post.Image
                                   }
                                   ).FirstOrDefault(); // Get all posts and comment as PostAndCommentsModel.
                list.Add(postAndComments);
            }

            return list;
        }

        public void InsertPost(PostDTO post)
        {
            if (post == null)
                throw new ValidationException("Argument is null", nameof(post));

            Post postEntity = ToDalEntity(post);
            if (post.ImageForm != null)
                postEntity.Image = $"Post{postEntity.UserId}{DateTime.UtcNow.ToString().Replace(" ", "").Replace(":", "")}.jpeg";

            UnitOfWork.Post.Create(postEntity);

            if (post.ImageForm != null)
            {
                MemoryStream ms = new MemoryStream(post.ImageForm.GetBytes().Result);

                Task.Run(() => AddImage.UploadFile(ms, $"Post{postEntity.UserId}{DateTime.UtcNow.ToString().Replace(":","").Replace(" ","")}.jpeg"));
            }
            
            UnitOfWork.Save();
        }


        public void UpdatePost(PostDTO post)
        {
            if (post == null)
                throw new ValidationException("Argument is null", nameof(post));

            var element = (from posts in UnitOfWork.Post.GetAll() where posts.Id == post.Id select posts).FirstOrDefault(); // Get post by id.


            if (element != null)
            {
                Post postEntity = ToDalEntity(post);
                postEntity.Content = post.Content;
                postEntity.Title = post.Title;
             

                if (post.ImageForm != null)
                {
                    postEntity.Image = $"Post{postEntity.UserId}{DateTime.UtcNow.ToString().Replace(" ", "").Replace(":", "")}.jpeg";
                    MemoryStream ms = new MemoryStream(post.ImageForm.GetBytes().Result);

                    Task.Run(() => AddImage.UploadFile(ms, postEntity.Image));
                }

                UnitOfWork.Post.Update(postEntity);
                UnitOfWork.Save();
            }
            else
                throw new ValidationException("Comment not found", nameof(post));
        }
    }
}
