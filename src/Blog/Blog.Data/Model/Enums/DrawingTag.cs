using Blog.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Enums
{
    public class DrawingTag : TagModel<DrawingTags>
    {
        public IList<Drawing> Drawings { get; set; }
    }
}
