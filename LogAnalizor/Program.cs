using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalizor
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new LogParser(new FileDownLoader(), "..\\..\\..\\MvcMusicStore\\logs\\2018-04-15.log");
            parser.GetGroupedItemsInformation();
            parser.GetErrorsInformation();
            Console.ReadLine();
        }
    }
}
