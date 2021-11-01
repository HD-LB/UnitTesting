using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class FileLogger : ILogger
    {
        public void Log(string msg)
        {
            // write to file
        }
    }
}
