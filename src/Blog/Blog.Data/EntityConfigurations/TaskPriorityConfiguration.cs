using Blog.Data.Helpers;
using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EntityConfigurations
{
    public class TaskPriorityConfiguration : IEntityTypeConfiguration<UserTaskPriority>
    {
        public void Configure(EntityTypeBuilder<UserTaskPriority> builder)
        {
            var tags = UserTasksToArray();

            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.HasData(tags);
        }

        private UserTaskPriority[] UserTasksToArray()
        {
            return Enum.GetValues(typeof(UserTaskPriorities))
                .OfType<UserTaskPriorities>()
                .Select(x => new UserTaskPriority() { Id = x, PriorityValue = x.ToString() })
                .ToArray();
        }
    }
}
