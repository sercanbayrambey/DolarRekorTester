using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.Interface
{
    public interface IDollarManager
    {
        bool IsNewRecord(decimal value);
        void AddNewRecord(decimal value);
    }
}
