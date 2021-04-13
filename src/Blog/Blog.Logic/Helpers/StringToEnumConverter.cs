using Blog.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Logic.Helpers
{
    public class StringToEnumConverter<T>
        where T: Enum
    {
        public static T Convert(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public List<T> Convert(string[] values)
        {
            return new List<T>();
        }
    }
}
