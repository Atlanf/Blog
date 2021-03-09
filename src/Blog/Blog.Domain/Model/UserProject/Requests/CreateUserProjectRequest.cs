using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Model.UserProject.Requests
{
    public class CreateUserProjectRequest
    {
        [Required(ErrorMessage = "Title is required.", AllowEmptyStrings = false)]
        [MinLength(10, ErrorMessage = "Title is too short (10 - 50 characters for a title).")]
        [MaxLength(50, ErrorMessage = "Title is too long (10 - 50 characters for a title).")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "Description is too long (maximum length is 255 charactes).")]
        public string Description { get; set; }
    }
}
