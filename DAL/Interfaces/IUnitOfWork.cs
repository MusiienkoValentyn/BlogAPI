using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Comment> Comment { get; }
        IRepository<Post> Post { get; }
        void Save();
    }
}
