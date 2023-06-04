using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }

    delegate void LogDel(string text);

    public class _101
    {
        public _101()
        {
            var log = new Log();

            LogDel LogTextToScreenDel, LogTextToFileDel;

            LogTextToFileDel = new LogDel(log.LogTextToFile);
            LogTextToScreenDel = new LogDel(log.LogTextToScreen);

            LogDel multiLogDelegate = LogTextToFileDel + LogTextToScreenDel;

            multiLogDelegate("Rogerio Marinho");
        }
    }
}
