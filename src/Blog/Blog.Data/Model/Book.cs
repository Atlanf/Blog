using Blog.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Model
{
    public class Book : StoredFile
    {
        public string Author { get; set; }
        public string Description { get; set; }

        public IList<BookTag> BookTags { get; set; }
    }
}
