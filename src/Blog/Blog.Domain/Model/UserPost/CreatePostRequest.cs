using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserPost
{
    public class CreatePostRequest
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsPrivate { get; set; }
        public IList<PostTags> SelectedTags { get; set; }
        public IList<string> AttachedFiles { get; set; }
    }
}
