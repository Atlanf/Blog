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
    public class UserProjectEntityConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(b => b.IsActive)
                .HasDefaultValue(true);
            builder.Property(b => b.IsHidden)
                .HasDefaultValue(false);
        }
    }
}
