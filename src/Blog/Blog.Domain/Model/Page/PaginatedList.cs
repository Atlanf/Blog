using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.Page
{
    public class PaginatedList<T>: BaseResponse
    {
        public IList<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public bool HasPreviousPage 
        {
            get 
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < PageCount;
            }
        }
    }
}
