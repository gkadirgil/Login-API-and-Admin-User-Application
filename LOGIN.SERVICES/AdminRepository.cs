using LOGIN.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIN.SERVICES
{
    public class AdminRepository: IPersonRepository<Admin>
    {
        public string GetPersonInfoNavBarWitById(int id)
        {
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                Admin data = new Admin();
                data = context.Admins.Find(id);
                string AdminInfo = data.FirstName.ToUpper() + " " + data.LastName.ToUpper();
                return AdminInfo;

            }
        }

        public Admin GetPersonWithById(int id)
        {
            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.Find(id);
            }

            return data;
        }

        public Admin PersonLogin(string email, string password)
        {
            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.FirstOrDefault(x => x.Email ==email && x.Password == password);
                if (data != null && data.AdminId > 0 && data.IsActive == true)
                {
                    return data;
                }
            }
            return data;
        }
    }
}
