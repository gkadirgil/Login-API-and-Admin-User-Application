using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class MailModel
    {
        public int MailId { get; set; }
        public string FullName { get; set; }
        public string FromMail { get; set; }
        public string ToMail { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public string AdminName { get; set; }
    }
}
