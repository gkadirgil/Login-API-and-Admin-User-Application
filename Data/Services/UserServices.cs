using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Data.Services
{
    public class UserServices
    {
        public User UserLogin(Login model)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {

                data = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (data != null && data.UserId > 0)
                {
                    return data;
                }
            }
            return data;
        }
        public Admin AdminLogin(Login model)
        {

            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (data != null && data.AdminId > 0)
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
        public List<UserClaim> GetListUserClaimWithById(int id)
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {

                //result=context.UserClaims.Where(w => w.UserId == id).ToList();
                result = context.UserClaims.Where(w => w.UserId == id).OrderByDescending(x => x.RequestDate).ToList();
            }
            return result;
        }
        public List<UserClaim> GetAll()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.OrderByDescending(x => x.RequestDate).Where(w => w.IsActive == false).ToList();
            }

            return result;
        }
        public UserClaim GetDetail(int id)
        {
            UserClaim result = new UserClaim();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Find(id);
            }

            return result;
        }
        public List<UserClaim> GetListWithIsActive()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                //result = context.UserClaims.OrderByDescending(x => x.VerificationDate).ToList();
                result = context.UserClaims.Where(w => w.IsActive == true).ToList();

                return result;

            }


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
        public User GetUserWithById(int id)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Users.Find(id);
            }

            return data;
        }
        public void SendMail(MailModel model, string email,string password)
        {
            //Admin admin = new Admin();
            //email = admin.Email;
            //password = admin.Password;

            MailMessage mymail = new MailMessage();
            mymail.To.Add(model.ToMail);
            mymail.From = new MailAddress(model.FromMail);
            mymail.Subject = "You Have A Message From Admin";
            mymail.Body = "Mss/Mr" + " " + model.FullName + ";" + "<br><br>" + model.MailContent+ "<br><br><br>"+"Sincereley,"+"<br>"+model.AdminName;
            mymail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.Port = 587; // Port Numaber
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //NetworkCredential nc = new NetworkCredential(email, password);
            //smtp.Credentials = nc;


            smtp.Send(mymail);

        }

        
    }
}
