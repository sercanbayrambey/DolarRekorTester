using DolarRekorKirdiMi.Business.Interface;
using DolarRekorKirdiMi.Business.StaticVars;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.Concrete
{
    public class DollarManager : IDollarManager
    {
        public void AddNewRecord(decimal value)
        {
            IFileService fileService = new FileManager(StaticVariables.FILE_NAME);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(value.ToString());
            stringBuilder.Append("*");
            stringBuilder.Append(DateTime.Now.ToString());
            fileService.Write(stringBuilder.ToString());
        }

        public bool IsNewRecord(decimal value)
        {
            IFileService fileService = new FileManager(StaticVariables.FILE_NAME);
            var str = fileService.Read();

            if (string.IsNullOrEmpty(str))
                return true;

            var strArray = str.Split("*");
            var currentValue = Convert.ToDecimal(strArray[0]);

            if (value > currentValue)
                return true;

            return false;
        }
    }
}
