using LOGIN.DATA.Models;
using LOGIN.SERVICES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIN.SERVICES
{
    public class UserRequestRepository : IUserRequestRepository
    {
        public List<UserClaim> GetListUserRequestWithById(int id)
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Where(w => w.UserId == id).OrderByDescending(x => x.RequestDate).ToList();
            }
            return result;
        }
        public UserClaim GetUserRequestWithById(int id)
        {
            UserClaim result = new UserClaim();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Find(id);
            }

            return result;
        }
        public List<UserClaim> GetUserRequsetListFalse()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.OrderByDescending(x => x.RequestDate).Where(w => w.IsActive == false).ToList();
            }

            return result;
        }
        public List<UserClaim> GetUserRequsetListTrue()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Where(w => w.IsActive == true).ToList();

                return result;

            }


        }
    }
}
