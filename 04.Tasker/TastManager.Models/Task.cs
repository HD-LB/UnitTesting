using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastManager.Models
{
    public class Task
    {
        //Constructor
        public Task(string description, DateTime? deadline = null)
        {
            this.Description = description;
            this.Deadline = (DateTime)deadline;
            this.IsDone = false;

        }


        //Fields
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsDone { get; set; }
    }
}
