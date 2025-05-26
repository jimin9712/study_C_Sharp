using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLinq
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    internal class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile { Name ="이지민", Height = 158 },
                new Profile { Name ="이유진", Height = 178 },
                new Profile { Name ="용호중", Height = 172 },
                new Profile { Name ="이세찬", Height = 171 },
                new Profile { Name ="안민혁", Height = 186 }
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           select new
                           {
                            Name = profile.Name, 
                            InchHeight =  profile.Height * 0.393
                           };
            foreach(var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}
