using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model.Enums
{
    public class PostTag
    {
        public PostTags Id { get; set; }
        public string TagName { get; set; }

        public IList<UserPost> Posts { get; set; }
    }
}
