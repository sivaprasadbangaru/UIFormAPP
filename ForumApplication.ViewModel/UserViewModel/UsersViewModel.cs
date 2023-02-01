using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ViewModel.UserViewModel
{
    public class UsersViewModel
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public bool IsAdmin { get; set; }
    }
}
