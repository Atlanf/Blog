using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class PageInfo
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; }
        public string SearchRequest { get; set; }
        public string Filter { get; set; }
    }
}
