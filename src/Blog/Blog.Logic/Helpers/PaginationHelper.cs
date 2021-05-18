using Blog.Domain.Model.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Helpers
{
    public class PaginationHelper<T>
    {
        public static PaginatedList<T> SetPaginatedList(List<T> sourceObject, PageInfo pageInfo, int totalItems)
        {
            var result = new PaginatedList<T>()
            {
                Items = new List<T>(sourceObject),
                PageIndex = pageInfo.Page,
                PageCount = (int)Math.Ceiling(totalItems / (double)pageInfo.PageSize)
            };

            return result;
        }
    }
}
