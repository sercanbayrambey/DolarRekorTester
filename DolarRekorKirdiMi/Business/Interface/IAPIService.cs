using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.Interface
{
    public interface IAPIService
    {
        /// <summary>   
        /// Gets the currency rates and returns string json.
        /// </summary>
        /// <returns>Json String</returns>
        string GetCurrencyRates();
        decimal GetTRYValue(string json);
    }
}
