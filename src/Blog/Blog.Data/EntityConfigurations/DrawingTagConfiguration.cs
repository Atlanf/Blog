using Blog.Data.Helpers;
using Blog.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data.EntityConfigurations
{
    class DrawingTagConfiguration : IEntityTypeConfiguration<DrawingTag>
    {
        public void Configure(EntityTypeBuilder<DrawingTag> builder)
        {
            var tags = TagsToArray();

            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.HasData(tags);
        }

        private DrawingTag[] TagsToArray()
        {
            return Enum.GetValues(typeof(DrawingTags))
                .OfType<DrawingTags>()
                .Select(x => new DrawingTag() { Id = x, TagName = x.ToString() })
                .ToArray();
        }
    }
}
