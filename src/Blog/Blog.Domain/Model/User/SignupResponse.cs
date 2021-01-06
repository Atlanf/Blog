using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.User
{
    public class SignupResponse
    {
        public bool Successful { get; set; }
        public IList<string> Errors { get; set; }
    }
}
