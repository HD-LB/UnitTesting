//https://my.telerikacademy.com/Courses/LectureResources/Video/8584/Видео-26-юли-2016-Мартин

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastManager.Models
{
    public class Tasker
    {
        //Field
        private ILogger logger;
        private IIdProvider idProvider;

        //Constructor
        public Tasker(ILogger logger, IIdProvider idProvider)
        {
            this.Tasks = new List<Task>();
            this.logger = logger;
            this.idProvider = idProvider;
        }

        //Propartie
        public ICollection<Task> Tasks { get; set; }

        //Methods
        public void Save(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();

            }
            task.Id = idProvider.Id;
            this.Tasks.Add(task);
            this.logger.Log(string.Format("Added Task with {0}", task.Id));
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
            this.logger.Log($"Task with {id} has been removed.");
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
