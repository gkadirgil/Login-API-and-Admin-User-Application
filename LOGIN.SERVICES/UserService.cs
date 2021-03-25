using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LOGIN.SERVICES
{
    public class UserService
    {
       
        public User UserLogin(Login model)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {

                data = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (data != null && data.UserId > 0 && data.IsActive == true)
                {
                    return data;
                }
            }
            return data;
        }
        public bool CheckEmail(string email)
        {
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                var Value_User = context.Users.Where(w => w.Email == email).Select(s => s.Email).FirstOrDefault();
                var Value_Admin = context.Admins.Where(w => w.Email == email).Select(s => s.Email).FirstOrDefault();

                if (Value_User == null && Value_Admin == null)
                {
                    return true;
                }
                else
                    return false;
            }


        }
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
        public User GetUserWithById(int id)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Users.Find(id);
            }

            return data;
        }
        public string GetUserInfoNavBarWitById(int id)
        {
           
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                User data = new User();
                data = context.Users.Find(id);
                string UserInfo = data.FirstName.ToUpper() + " " + data.LastName.ToUpper();
                return UserInfo;

            }

        } 
    }
}
