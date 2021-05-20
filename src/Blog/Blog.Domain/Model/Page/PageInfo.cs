using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.Page
{
    public class PageInfo
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 5;
        [FromQuery(Name = "search")]
        public string SearchRequest { get; set; } = "";
    }
}
