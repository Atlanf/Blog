using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class UserProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsHidden { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public IList<UserTask> UserTasks { get; set; }
    }
}
