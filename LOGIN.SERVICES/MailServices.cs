using Data.Models;
using LOGIN.DATA.Models;
using System.Net;
using System.Net.Mail;

namespace LOGIN.SERVICES
{
    public class MailServices
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
    }
}
