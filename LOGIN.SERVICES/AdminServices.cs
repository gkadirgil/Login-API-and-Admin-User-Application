using Data.Models;
using LOGIN.DATA.Models;
using System.Linq;
using System.Security.Claims;

namespace LOGIN.SERVICES
{
    public class AdminServices
    {
        public Admin AdminLogin(Login model)
        {

            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (data != null && data.AdminId > 0 && data.IsActive == true)
                {
                    return data;
                }
            }
            return data;
        }
        public Admin GetAdminWithById(int id)
        {
            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.Find(id);
            }

            return data;
        }
        public string GetAdminInfoNavBarWitById(int id)
        {
            //UserServices userServices = new UserServices();

            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                Admin data = new Admin();
                data = context.Admins.Find(id);
                string AdminInfo = data.FirstName.ToUpper() + " " + data.LastName.ToUpper();
                return AdminInfo;

            }

        }

    }
}
