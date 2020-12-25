using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class User : IdentityUser
    {
        public IList<Drawing> Drawings { get; set; }
        public IList<Book> Books { get; set; }
        public IList<UserProject> UserProjects { get; set; }
    }
}
