using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalizor
{
    enum LogTypes
    {
        INFO,
        DEBUG,
        ERROR
    }

    class LogItem
    {
        public DateTime Date { get; set; }
        public LogTypes LogType { get; set; }
        public string Message { get; set; } 
    }
}
