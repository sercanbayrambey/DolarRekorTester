using DolarRekorKirdiMi.Business.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DolarRekorKirdiMi.Business
{
    public class APIManager : IAPIService
    {
        public string GetCurrencyRates()
        {
            try
            {

                using var client = new HttpClient();
                var result = client.GetAsync("https://api.exchangeratesapi.io/latest?symbols=USD,TRY&base=USD").Result;
                if (result.IsSuccessStatusCode)
                    return result.Content.ReadAsStringAsync().Result;
                throw new Exception("Server ERROR");
            }
            catch
            {
                throw new Exception("Server ERROR!");
            }
        }

        public decimal GetTRYValue(string json)
        {
            try
            {

                var obj = JsonConvert.DeserializeObject<dynamic>(json);
                return obj.rates.TRY;
            }
            catch
            {
                throw new Exception("Parse ERROR!");
            }
        }
    }
}
