using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.Interface
{
    public interface IMailService
    {
        void SendMail(string email, string subject, string body);
        string BuildMailBody(string baseBody, string dollarValue, string date);
    }
}
