using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class BookTag
    {
        public BookTags Id { get; set; }
        public string TagName { get; set; }

        public IList<Book> Books { get; set; }
    }
}
