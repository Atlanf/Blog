using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject.Responses
{
    public class ActiveUserProjectsPreviewResponse
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ShortName { get; set; }
        public double PriorityRatio { get; set; }
        public int HighPriorityTaskCount { get; set; }
        public int UnfinishedTaskCount { get; set; }
        public DateTime LastFinishedTask { get; set; }
    }
}
