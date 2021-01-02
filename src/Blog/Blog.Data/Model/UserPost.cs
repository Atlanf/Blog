using Blog.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model
{
    public class UserPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime LastEdit { get; set; }
        public bool Edited { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPrivate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public IList<StoredFile> AttachedFiles { get; set; }

        public IList<PostTag> PostTags { get; set; }
    }
}
