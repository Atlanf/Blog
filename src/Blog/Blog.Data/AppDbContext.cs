using Blog.Data.EntityConfigurations;
using Blog.Data.Helpers;
using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<StoredFile> StoredFiles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<BookTag>().ToTable("BookTags");
            builder.Entity<Drawing>().ToTable("Drawings");
            builder.Entity<DrawingTag>().ToTable("DrawingTags");
            builder.Entity<PostTag>().ToTable("PostTags");
            builder.Entity<UserTaskPriorityTag>().ToTable("UserTaskPriorities");

            builder.ApplyConfiguration(new TagConfiguration<BookTag, BookTags>());
            builder.ApplyConfiguration(new TagConfiguration<DrawingTag, DrawingTags>());
            builder.ApplyConfiguration(new TagConfiguration<PostTag, PostTags>());
            builder.ApplyConfiguration(new TagConfiguration<UserTaskPriorityTag, UserTaskPriorityTags>());
        }
    }
}
