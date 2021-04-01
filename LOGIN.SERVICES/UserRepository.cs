using Data.Models;
using LOGIN.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIN.SERVICES
{
    public class UserRepository : IPersonRepository<User>
    {
        public string GetPersonInfoNavBarWitById(int id)
        {
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                User data = new User();
                data = context.Users.Find(id);
                string UserInfo = data.FirstName.ToUpper() + " " + data.LastName.ToUpper();
                return UserInfo;

            }
        }

        public User GetPersonWithById(int id)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Users.Find(id);
            }

            return data;
        }

        public User PersonLogin(string email, string password)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {

                data = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (data != null && data.UserId > 0 && data.IsActive == true)
                {
                    return data;
                }
            }
            return data;
        }
       
       
    }
}
