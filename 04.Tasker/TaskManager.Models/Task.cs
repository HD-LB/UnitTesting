using System;

namespace TaskManager.Models
{
    public class Task
    {
        public Task(string description, DateTime? deadLine = null)
        {
            this.Description = description;
            this.Deadline = deadLine;
            this.IsDone = false;
        }
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsDone { get; set; }
    }
}
