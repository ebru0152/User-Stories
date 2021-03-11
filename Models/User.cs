using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Stories_part_4.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public User(string name, string email, string image)
        {
            Name = name;
            Email = email;
            Image = image;
        }
    }
}
