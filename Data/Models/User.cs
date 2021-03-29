using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LOGIN.DATA.Models
{
    public partial class User
    {
        public User()
        {
            UserClaims = new HashSet<UserClaim>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime RegisterTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}
