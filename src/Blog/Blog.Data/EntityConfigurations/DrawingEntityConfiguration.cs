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
    public class DrawingEntityConfiguration : IEntityTypeConfiguration<Drawing>
    {
        public void Configure(EntityTypeBuilder<Drawing> builder)
        {
            builder.ToTable("Drawings");

            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
