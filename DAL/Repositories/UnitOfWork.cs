using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private Repository<Comment> commentRepository;
        private Repository<Post> postRepository;

        public UnitOfWork(BlogContext db)
        {
            this.db = db;
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
