
namespace TaskManager.Client
{
    using System;

    using TastManager.Models;

    public class Program
    {
        static void Main(string[] args)
        {
            var consoleLogger = new ConsoleLogger();
            var idProvider = new IdProvider();

            var taskManager = new Tasker(consoleLogger, idProvider);
                       
            var task1 = new Task("Buy something", DateTime.Now.AddDays(2));
            var task2 = new Task("Move something.", DateTime.Now.AddDays(2));
            var task3 = new Task("Get something.", DateTime.Now.AddDays(2));

            taskManager.Save(task1);
            taskManager.Save(task2);
            taskManager.Delete(2);
            taskManager.Save(task3);
        }
    }
}
