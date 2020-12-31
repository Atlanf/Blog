using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public UserTaskPriorities PriorityId { get; set; }
        public UserTaskPriority Priority { get; set; }

        public int ProjectId { get; set; }
        public UserProject Project { get; set; }
    }
}
