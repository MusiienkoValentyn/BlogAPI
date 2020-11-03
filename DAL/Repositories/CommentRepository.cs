using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class CommentRepository : Repository<Comment>
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
