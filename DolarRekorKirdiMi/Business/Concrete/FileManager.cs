using DolarRekorKirdiMi.Business.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DolarRekorKirdiMi.Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly string FILE_NAME;

        public FileManager(string fileName)
        {
            FILE_NAME = fileName;
        }
        public string Read()
        {
            if (File.Exists(FILE_NAME))
            {

                using (StreamReader reader = new StreamReader(FILE_NAME))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                File.Create(FILE_NAME).Close();
                return null;
            }
        }

        public void Write(string s)
        {
            if (File.Exists(FILE_NAME))
            {

                using (StreamWriter writer = new StreamWriter(FILE_NAME))
                {
                    writer.WriteLine(s);
                }
            }
            else
            {
                File.Create(FILE_NAME).Close();
                return;
            }
        }
    }
}
