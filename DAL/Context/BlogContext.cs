using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Meska", Password = "1221" },
                                                new User { Id = 2, UserName = "Valentyn99", Password = "2222" });

            modelBuilder.Entity<Post>().HasData(new Post { Id = 1, UserId = 2, Title = "The best day", Content = "Today I`ve visited London" },
                                                new Post { Id = 2, UserId = 1, Title = "My first work day", Content = "It was so cool. I`ve waited really long time for it.", Image = null });

            modelBuilder.Entity<Comment>().HasData(new Comment { Id = 312, UserId = 1, PostId = 1, Content = "It is awesome place!!!" },
                                                   new Comment { Id = 241, UserId = 2, PostId = 2, Content = "I congratulate you, buddy" });


        }

    }
}
