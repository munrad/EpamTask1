using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask1.Core.Extensions
{
    public class Logger
    {
        public static void AddToLog(string message)
        {
            File.AppendAllText("error.log", $"{DateTime.Now.ToUniversalTime()}: {message}{Environment.NewLine}");
        }
    }
}
