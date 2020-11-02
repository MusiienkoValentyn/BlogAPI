using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class PostRepository : Repository<CommentRepository>
    {
        public PostRepository(DbContext context) : base(context)
        {
        }
    }
}
