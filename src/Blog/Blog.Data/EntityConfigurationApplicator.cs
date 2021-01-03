using Blog.Data.Model.Enums;
using Blog.Domain.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EntityConfigurations
{
    public class EntityConfigurationApplicator
    {
        public ModelBuilder ApplyCustomConfigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TagConfiguration<BookTag, BookTags>());
            builder.ApplyConfiguration(new TagConfiguration<DrawingTag, DrawingTags>());
            builder.ApplyConfiguration(new TagConfiguration<PostTag, PostTags>());
            builder.ApplyConfiguration(new TagConfiguration<UserTaskPriorityTag, UserTaskPriorityTags>());

            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new DrawingEntityConfiguration());
            builder.ApplyConfiguration(new UserPostEntityConfiguration());
            builder.ApplyConfiguration(new UserProjectEntityConfiguration());
            builder.ApplyConfiguration(new UserTaskEntityConfiguration());

            return builder;
        }
    }
}
