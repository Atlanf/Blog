using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class StoredFileInfo
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string UniqueName { get; set; }
        public DateTime DateUploaded { get; set; }
        public string StorageUrl { get; set; }
        public long FileSize { get; set; }

    }
}
