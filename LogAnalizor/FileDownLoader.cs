using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalizor
{
    class FileDownLoader: IFileDownLoader
    {
        public List<string> Download(string path)
        {
           return File.ReadAllLines(path).ToList();
        }
    }
}
