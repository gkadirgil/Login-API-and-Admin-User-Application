using LOGIN.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIN.SERVICES.IRepository
{
    public interface IMailRepository
    {
        public void SendMail(MailModel model, string email, string password);
        public bool CheckEmail(string email);

    }
}
