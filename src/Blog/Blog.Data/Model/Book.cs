using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Author { get; set; }

        public IList<BookTag> BookTags { get; set; }
    }
}
