using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.Models.ViewModels
{
    public class UserMyRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string UserDocument { get; set; }
        public string DocumentPath { get; set; }
    }
}
