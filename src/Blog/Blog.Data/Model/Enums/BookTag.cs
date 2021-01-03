using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Enums
{
    public class BookTag : TagModel<BookTags>
    {
        public IList<Book> Books { get; set; }
    }
}
