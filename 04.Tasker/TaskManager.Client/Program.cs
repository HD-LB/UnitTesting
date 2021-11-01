using System;
using TaskManager.Models;

namespace TaskManager.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogger = new FileLogger();
            var idProvider = new IdProvider();

            var taskManager = new Tasker(consoleLogger, idProvider);

            var task1 = new Models.Task("Buy something", DateTime.Now.AddDays(2));
            var task2 = new Models.Task("Move something.", DateTime.Now.AddDays(2));
            var task3 = new Models.Task("Get something.", DateTime.Now.AddDays(2));

            taskManager.Save(task1);
            taskManager.Save(task2);
            taskManager.Delete(2);
            taskManager.Save(task3);
        }
    }
}
