using LOGIN.DATA.Models;
using LOGIN.SERVICES.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LOGIN.SERVICES
{
    public class MailRepository: IMailRepository
    {
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
    }
}
