using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model
{
    public class UserTaskPriority
    {
        public UserTaskPriorities PriorityId { get; set; }
        public string PriorityValue { get; set; }
    }
}
