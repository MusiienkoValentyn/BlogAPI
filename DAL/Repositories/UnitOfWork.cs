using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private Repository<Comment> commentRepository;
        private Repository<Post> postRepository;
        private Repository<User> userRepository;

        public UnitOfWork(DbContextOptions<BlogContext> connectionString)
        {
            db = new BlogContext(connectionString);
        }

        public IRepository<Comment> Comment
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new Repository<Comment>(db);
                return commentRepository;
            }
        }

        public IRepository<Post> Post
        {
            get
            {
                if (postRepository == null)
                    postRepository = new Repository<Post>(db);
                return postRepository;
            }
        }

        public IRepository<User> User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<User>(db);
                return userRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {            
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
