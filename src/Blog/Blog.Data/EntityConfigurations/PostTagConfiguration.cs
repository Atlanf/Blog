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
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            var tags = TagsToArray();

            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.HasData(tags);
        }

        private PostTag[] TagsToArray()
        {
            return Enum.GetValues(typeof(PostTags))
                .OfType<PostTags>()
                .Select(x => new PostTag() { Id = x, TagName = x.ToString() })
                .ToArray();
        }
    }
}
