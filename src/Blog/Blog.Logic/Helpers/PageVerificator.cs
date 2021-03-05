using Blog.Domain;
using Blog.Domain.Model.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Helpers
{
    public class PageVerificator
    {
        private static readonly int _maxPageSize = 20;

        public static PageInfo AdjustPage(PageInfo page)
        {
            if (page.PageSize >= _maxPageSize)
            {
                page.PageSize = _maxPageSize;
            }
            if (page.Page < 1)
            {
                page.Page = 1;
            }
            return page;
        }
    }
}
