using System;
using System.Collections.Generic;
using System.Text;

namespace DolarRekorKirdiMi.Business.Interface
{
    public interface IFileService
    {
        void Write(string s);
        string Read();
    }
}
