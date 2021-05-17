using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject.Responses
{
    public class UserProjectMinimizedResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UnfinishedTasks { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
