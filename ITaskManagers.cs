﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface ITaskManagers
    {
        void AddTask(string title);
        Task RemoveTask(string title);
        List<Task> ListTasks();
    }
}
