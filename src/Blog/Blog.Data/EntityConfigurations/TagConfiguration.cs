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
    public class TagConfiguration<T, E> : IEntityTypeConfiguration<T>
        where T : TagModel<E>, new()
        where E : Enum
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            var tags = TagsToArray();

            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.HasData(tags);
        }

        private T[] TagsToArray()
        {
            return Enum.GetValues(typeof(E))
                .OfType<E>()
                .Select(x => new T() { Id = x, Name = x.ToString() })
                .ToArray();
        }
    }
}
