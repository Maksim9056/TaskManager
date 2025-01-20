using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskManagers : ITaskManagers
    {
       List<Task> tasks = new List<Task>();

        public void AddTask(string title)
        {
            tasks.Add(new TaskManager.Task() { Title = title });
        }

  
        public List<Task> ListTasks()
        {
            return tasks;

        }

        public Task RemoveTask(string title)
        {
            var Book = tasks.Find(x => x.Title == title);
            if (Book == null)
            {
              return new Task();

            }
            tasks.Remove(Book);
            return new Task() { Title ="",Description ="",приоритет =""};
        }
    }
}
