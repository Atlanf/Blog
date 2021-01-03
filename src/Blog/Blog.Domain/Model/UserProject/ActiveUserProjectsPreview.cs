﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject
{
    public class ActiveUserProjectsPreview
    {
        public int UserProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public double PriorityRatio { get; set; }
        public int HighPriorityTaskCount { get; set; }
        public int UnfinishedTaskCount { get; set; }
        public DateTime LastFinishedTask { get; set; }
    }
}