using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prg_project.Models
{
    internal class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public User(string userId, string userName, string password, string email)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
