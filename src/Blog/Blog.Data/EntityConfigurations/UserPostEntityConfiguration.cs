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
    public class UserPostEntityConfiguration : IEntityTypeConfiguration<UserPost>
    {
        public void Configure(EntityTypeBuilder<UserPost> builder)
        {
            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(b => b.IsPrivate)
                .HasDefaultValue(false);
            builder.Property(b => b.Edited)
                .HasDefaultValue(false);
        }
    }
}
