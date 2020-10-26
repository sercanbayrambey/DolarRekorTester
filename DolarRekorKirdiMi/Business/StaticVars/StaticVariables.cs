using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.StaticVars
{
    public static class StaticVariables
    {
        public const string FILE_NAME = "dollar_logs.txt";
        public const int CHECK_TIME = 120;
        public const string SERVICE_MAIL = "comporeport@gmail.com";
        public const string SERVICE_MAIL_PASS = "password";
        public const string SERVICE_MAIL_SUBJECT = "Dolar Yeni Bir Rekor Kırdı!";
        public const string SERVICE_MAIL_BASE_BODY = "<h1> Dolar yeni bir rekor kırdı. </h1>";
        public const string SEND_EMAIL_TO = "sercanbayrambeyy@gmail.com";
    }
}
