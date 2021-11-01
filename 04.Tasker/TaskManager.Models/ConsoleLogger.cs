using System;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
