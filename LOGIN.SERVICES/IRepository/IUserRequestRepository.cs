using LOGIN.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIN.SERVICES.IRepository
{
    public interface IUserRequestRepository
    {
        public List<UserClaim> GetListUserRequestWithById(int id);
        public UserClaim GetUserRequestWithById(int id);
        public List<UserClaim> GetUserRequsetListFalse();
        public List<UserClaim> GetUserRequsetListTrue();
    }
}
