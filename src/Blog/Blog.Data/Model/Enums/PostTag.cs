using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model.Enums
{
    public class PostTag : TagModel<PostTags>
    {
        public IList<UserPost> Posts { get; set; }
    }
}
