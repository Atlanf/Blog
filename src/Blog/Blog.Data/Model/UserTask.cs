using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class UserTask
    {
        public int Id { get; set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public int ProjectId { get; set; }
        public UserProject UserProject { get; set; }
    }
}
