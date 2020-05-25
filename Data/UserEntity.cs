﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual UserProfileEntity UserProfile { get; set; }
    }
}