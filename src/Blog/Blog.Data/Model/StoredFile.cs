using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class StoredFile
    {
        public Guid Id { get; set; }
        public string FileUniqueName { get; set; }
        public string FileName { get; set; }
        public DateTime DateUploaded { get; set; }
        public string StorageUrl { get; set; }
        public long FileSize { get; set; }
        public bool IsImage { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
