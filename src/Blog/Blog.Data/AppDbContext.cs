using Blog.Data.EntityConfigurations;
using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Blog.Domain.Model.Enum;
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
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<DrawingTag> DrawingTags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder = new EntityConfigurationApplicator().ApplyCustomConfigurations(builder);

            builder.Entity<BookTag>().ToTable("BookTags");
            builder.Entity<DrawingTag>().ToTable("DrawingTags");
            builder.Entity<PostTag>().ToTable("PostTags");
            builder.Entity<UserTaskPriorityTag>().ToTable("UserTaskPriorities");
        }
    }
}
