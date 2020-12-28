using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model
{
    public class User : IdentityUser
    {
        public IList<UserProject> UserProjects { get; set; }
        public virtual IList<StoredFile> StoredFiles { get; set; }
    }
}
