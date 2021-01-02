using Blog.Data.Helpers;
using Blog.Data.Model;
using Blog.Data.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data.EntityConfigurations
{
    public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            var tags = TagsToArray();

            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.HasData(tags);
        }

        private BookTag[] TagsToArray()
        {
            return Enum.GetValues(typeof(BookTags))
                .OfType<BookTags>()
                .Select(x => new BookTag() { Id = x, TagName = x.ToString() })
                .ToArray();
        }
    }
}
