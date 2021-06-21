using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject.Responses
{
    public class UserProjectDetailsResponse: BaseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
