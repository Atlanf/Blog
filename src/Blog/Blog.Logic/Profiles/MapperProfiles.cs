using AutoMapper;
using Blog.Data.Model;
using Blog.Domain.Model.UserProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Logic.Profiles
{
    public class MapperProfiles
    {
        public static List<Profile> SetProfiles()
        {
            var profiles = new List<Profile>()
            {
                new UserProjectProfile()
            };

            return profiles;
        }
    }
}
