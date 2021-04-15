using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserTask.Responses
{
    public class UserTaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public int Priority { get; set; }
        public DateTime ExpectedFinish { get; set; }
    }
}
