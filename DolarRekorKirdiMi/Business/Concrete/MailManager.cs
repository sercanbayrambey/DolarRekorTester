using DolarRekorKirdiMi.Business.Interface;
using DolarRekorKirdiMi.Business.StaticVars;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DolarRekorKirdiMi.Business.Concrete
{
    public class MailManager :IMailService
    {
        public static void SendMail(string email)
        {
           
        }

        public string BuildMailBody(string baseBody, string dollarValue, string date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(baseBody);
            stringBuilder.AppendLine($"<h3>Doların şu anki rekoru: {dollarValue} Rekorun kırıldığı tarih: {date}</h3>");
            return stringBuilder.ToString();
        }

        public void SendMail(string email, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(StaticVariables.SERVICE_MAIL);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(StaticVariables.SERVICE_MAIL, StaticVariables.SERVICE_MAIL_PASS),
                    Timeout = 20000
                };

                smtp.Send(mail);
            }
        }
    }
}
