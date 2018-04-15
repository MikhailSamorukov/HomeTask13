using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalizor
{
    class LogParser
    {
        private readonly IFileDownLoader _downloader;

        private List<LogItem> _result;

        public LogParser(IFileDownLoader downloader, string path)
        {
            _downloader = downloader;
            Parse(path);
        }

        public void GetGroupedItemsInformation()
        {
            var grupedElems = from elem in _result
                group elem by elem.LogType
                into gr
                select new
                {
                    GroupName = gr.Key.ToString(),
                    Count = gr.Count()
                };
            foreach (var element in grupedElems)
            {
                Console.WriteLine($"group Name: {element.GroupName}, Count: {element.Count}");
            }
        }

        public void GetErrorsInformation()
        {
            var errors = _result.Where(item => item.LogType == LogTypes.ERROR);

            foreach (var element in errors)
            {
                Console.WriteLine($"ERROR: {element.Message}");
            }
        }

        private void Parse(string path)
        {
            _result = new List<LogItem>();
            var logItems = _downloader.Download(path);
            foreach (var logItem in logItems)
            {
                var splitedRow = logItem.Split(' ');
                try
                {
                    _result.Add(new LogItem()
                    {
                        Date = DateTime.Parse($"{splitedRow[0]} {splitedRow[1]}"),
                        LogType = (LogTypes) Enum.Parse(typeof(LogTypes), splitedRow[2]),
                        Message = string.Join(" ", splitedRow.Skip(3)),
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
