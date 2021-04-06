using LOGIN.DATA.Models;
using LOGIN.SERVICES.IRepository;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public MailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
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
            smtp.Port = int.Parse(_configuration["EmailSettings:Port"]);
            smtp.Host = _configuration["EmailSettings:Host"].ToString();
            smtp.EnableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"]);

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
