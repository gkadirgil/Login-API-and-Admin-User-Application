using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
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
                if (data != null && data.UserId > 0 && data.IsActive == true)
                {
                    return data;
                }
            }
            return data;
        } // Added//
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
        }//
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


        } //Added//
        public List<UserClaim> GetListUserRequestWithById(int id)
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Where(w => w.UserId == id).OrderByDescending(x => x.RequestDate).ToList();
            }
            return result;
        } //Added//
        public UserClaim GetUserRequestWithById(int id)
        {
            UserClaim result = new UserClaim();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Find(id);
            }

            return result;
        } //Added//
        public List<UserClaim> GetUserRequsetListFalse()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.OrderByDescending(x => x.RequestDate).Where(w => w.IsActive == false).ToList();
            }

            return result;
        } //Added//
        public List<UserClaim> GetUserRequsetListTrue()
        {
            List<UserClaim> result = new List<UserClaim>();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                result = context.UserClaims.Where(w => w.IsActive == true).ToList();

                return result;

            }


        } //Added//
        public Admin GetAdminWithById(int id)
        {
            Admin data = new Admin();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Admins.Find(id);
            }

            return data;
        }//
        public User GetUserWithById(int id)
        {
            User data = new User();
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                data = context.Users.Find(id);
            }

            return data;
        } //Added//
        public void SendMail(MailModel model, string email, string password)
        {
           
            MailMessage mymail = new MailMessage();
            mymail.To.Add(model.ToMail);
            mymail.From = new MailAddress(model.FromMail);
            mymail.Subject = "You Have A Message From Admin";
            mymail.Body = "Mss/Mr" + " " + model.FullName + ";" + "<br><br>" + model.MailContent + "<br><br><br>" + "Sincereley," + "<br>" + model.AdminName;
            mymail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(email, password);
            smtp.Port = 587; // Port Numaber
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(mymail);

        }
        public string GetUserInfoNavBarWitById(int id)
        {
            UserServices userServices = new UserServices();
            
            using (LOGAPDBContext context = new LOGAPDBContext())
            {
                User data = new User();
                data = context.Users.Find(id);
                string UserInfo = data.FirstName.ToUpper() + " " + data.LastName.ToUpper();
                return UserInfo;

            }

        } //Added//
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

        }//



    }
}
