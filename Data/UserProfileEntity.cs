using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UserProfileEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}
