using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject.Responses
{
    public class UserProjectDetailsResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsError { get; set; } = false;
        public string AdditionalInfo { get; set; }
    }
}
