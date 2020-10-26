using DolarRekorKirdiMi.Business;
using DolarRekorKirdiMi.Business.Concrete;
using DolarRekorKirdiMi.Business.Interface;
using DolarRekorKirdiMi.Business.StaticVars;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DolarRekorKirdiMi
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread checkerTh = new Thread(new ThreadStart(CheckDollar));
            checkerTh.Start();
        }

        static void CheckDollar()
        {
            IAPIService apiService = new APIManager();
            IDollarManager dollarManager = new DollarManager();
            IMailService mailService = new MailManager();
            
            while (true)
            {
                Console.WriteLine($"\n\n<!> [{DateTime.Now}] Dolar kontrol ediliyor..");
                var tryValue = apiService.GetTRYValue(apiService.GetCurrencyRates());
                if(dollarManager.IsNewRecord(tryValue))
                {
                    dollarManager.AddNewRecord(tryValue);
                    Console.WriteLine($"<!> [{DateTime.Now}] Dolar yeni rekor kırdı :( Şu anki rekor: {tryValue}");
                    mailService.SendMail(StaticVariables.SEND_EMAIL_TO,StaticVariables.SERVICE_MAIL_SUBJECT,mailService.BuildMailBody(StaticVariables.SERVICE_MAIL_BASE_BODY,tryValue.ToString(),DateTime.Now.ToString()));
                }
                else
                {
                    Console.WriteLine($"<!> [{DateTime.Now}] Dolar yeni bir rekor kırmadı. Şu anki durum: {tryValue}");
                }

                Thread.Sleep(StaticVariables.CHECK_TIME * 1000);

            }
        }
    }
}
