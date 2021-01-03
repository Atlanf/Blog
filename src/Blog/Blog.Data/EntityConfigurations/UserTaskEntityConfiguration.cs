using Blog.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EntityConfigurations
{
    public class UserTaskEntityConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
