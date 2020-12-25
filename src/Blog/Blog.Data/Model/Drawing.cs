using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class Drawing
    {
        public Guid Id { get; set; }
        public string DrawingName { get; set; }
        public string UniqueName { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public IList<DrawingTag> DrawingTags { get; set; }

        public Guid FileInfoId { get; set; }
        public StoredFileInfo FileInfo { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
