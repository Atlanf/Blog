using Blog.Data.Model.Enums;
using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public DateTime ExpectedFinish { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public UserTaskPriorityTags PriorityId { get; set; }
        public virtual UserTaskPriorityTag Priority { get; set; }

        public int ProjectId { get; set; }
        public UserProject Project { get; set; }
    }
}
