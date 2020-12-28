using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Model
{
    public class Drawing : StoredFile
    {
        public DateTime DateCompleted { get; set; }
        public string Description { get; set; }

        public IList<DrawingTag> DrawingTags { get; set; }
    }
}
