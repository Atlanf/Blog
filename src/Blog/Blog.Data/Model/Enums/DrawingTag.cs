using Blog.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Model.Tags
{
    public class DrawingTag
    {
        public DrawingTags Id { get; set; }
        public string TagName { get; set; }

        public IList<Drawing> Drawings { get; set; }
    }
}
