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
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(10, ErrorMessage = "Title is too short (10 - 50 characters for a title).")]
        [MaxLength(50, ErrorMessage = "Title is too long (10 - 50 characters for a title).")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short name is required.")]
        [MinLength(5, ErrorMessage = "Name is too short (4 - 25 characters for a name).")]
        [MaxLength(25, ErrorMessage = "Name is too long (4 - 25 characters for a name).")]
        public string ShortName { get; set; }

        [MaxLength(255, ErrorMessage = "Description is too long (maximum length is 255 charactes).")]
        public string Description { get; set; }
    }
}
