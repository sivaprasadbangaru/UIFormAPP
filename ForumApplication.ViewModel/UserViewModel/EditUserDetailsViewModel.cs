﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.ViewModel.UserViewModel
{
    public class EditUserDetailsViewModel
    {
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}
