using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.Models.ViewModels
{
    public class UserRequestDTO
    {
        public int ClaimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserDescription { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
