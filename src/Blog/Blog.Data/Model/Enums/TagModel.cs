using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model.Enums
{
    public class TagModel<T>
        where T: Enum
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
