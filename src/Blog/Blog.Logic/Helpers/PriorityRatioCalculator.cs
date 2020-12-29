using Blog.Data.Model;
using Blog.Domain.Model.UserProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Helpers
{
    public class PriorityRatioCalculator
    {
        public static double SetPriorityRatio(UserProject userProject)
        {
            double totalTasks = userProject.UserTasks.Count();
            double totalPriority = 0;

            foreach(var task in userProject.UserTasks)
            {
                totalPriority += (int)task.Priority.PriorityId;
            }

            return Math.Round(totalPriority / totalTasks, 2) * 100;
        }
    }
}
