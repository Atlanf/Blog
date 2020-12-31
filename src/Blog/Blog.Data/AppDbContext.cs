using Blog.Data.EntityConfigurations;
using Blog.Data.Helpers;
using Blog.Data.Model;
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

        public AppDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Drawing>().ToTable("Drawings");

            builder.ApplyConfiguration(new BookTagConfiguration());
            builder.ApplyConfiguration(new DrawingTagConfiguration());
            builder.ApplyConfiguration(new TaskPriorityConfiguration());
        }
    }
}
