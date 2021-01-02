﻿using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Model.Enums
{
    public class UserTaskPriority
    {
        public UserTaskPriorities Id { get; set; }
        public string PriorityValue { get; set; }

        public IList<UserTask> UserTasks { get; set; }
    }
}