using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class Tasker
    {
        private ILogger logger;
        private IIdProvider idProvider;

        public Tasker(ILogger logger, IIdProvider idProvider)
        {
            this.Tasks = new List<Task>();
            this.logger = logger;
            this.idProvider = idProvider;
        }

        public ICollection<Task> Tasks { get; set; }

        public Tasker()
        {
            this.Tasks = new List<Task>();
        }

        public void Save(Task task)
        {
            task.Id = idProvider.Id;
            this.Tasks.Add(task);
            try
            {
                this.logger.Log(string.Format($"Added task with : {task.Id}"));
            }
            catch (ArgumentNullException)
            {

            }

        }

        public void Delete(int id)
        {
            var taskFound = this.Tasks.SingleOrDefault(task => task.Id == id);

            if (taskFound == null)
            {
                this.logger.Log($"Task with {id} is not found.");
                return;
            }

            this.Tasks.Remove(taskFound);
            this.logger.Log($"Task with {id} has been removed");
        }

        public void AllTasks()
        {
            foreach (var task in this.Tasks)
            {
                this.logger.Log($"Task [{task.Id}]");
            }
        }
    }
}
