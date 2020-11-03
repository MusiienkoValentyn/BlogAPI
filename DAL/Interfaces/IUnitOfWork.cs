using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Comment> Comment { get; }
        IRepository<Post> Post { get; }
        IRepository<User> User { get; }
        void Save();
    }
}
