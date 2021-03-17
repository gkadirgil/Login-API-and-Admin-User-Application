using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class UserClaim
    {
        public int ClaimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserDescription { get; set; }
        public string DocumentPath { get; set; }
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? VerificationDate { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string AdminDescription { get; set; }
        public string AdminDetail { get; set; }
        public string UserDocument { get; set; }

        public virtual User User { get; set; }
    }
}
