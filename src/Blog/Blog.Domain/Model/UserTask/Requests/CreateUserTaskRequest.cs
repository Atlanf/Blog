using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserTask.Requests
{
    public class CreateUserTaskRequest
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title is too long (maximum length is 50 characters).")]
        public string Title { get; set; }
        public DateTime ExpectedFinish { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public string PriorityTag { get; set; }
    }
}
