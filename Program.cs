using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.Listeners.Add(new ConsoleTraceListener());

            Trace.Listeners.Add(new TextWriterTraceListener("TaskManager_log.txt"));

            //PerformanceCounter performanceCounter = new PerformanceCounter();
            //performanceCounter.
            TaskManagers taskManagers = new TaskManagers();
            Trace.WriteLine($"[INFO] Программа TaskManager запущена.");

            if (!EventLog.SourceExists("TaskManager"))
            {
                EventLog.CreateEventSource("TaskManager", "Application");
            }
            EventLog.WriteEntry("TaskManager", "Программа TaskManager запущена.", EventLogEntryType.Information);


            bool infiti = true;
            while (infiti)
            {
                Trace.WriteLine("Видите  команды (для проверки):\r\n");
                Trace.WriteLine("add");
                Trace.WriteLine("list");
                Trace.WriteLine("remove");
                Trace.WriteLine("exit");
                string command = Console.ReadLine();
                string TitleBook = "";
              
                try
                {
                    switch (command)
                    {
                        case "add":

                            Console.WriteLine("Программа просит ввести название задачи: «Учить C#».\r\n");


                            TitleBook = Console.ReadLine();



                            Trace.WriteLine($"[TRACE] Начало операции AddTask.");
                            taskManagers.AddTask(TitleBook);

                            EventLog.WriteEntry("TaskManager", "Задача \"Учить C#\" успешно добавлена.", EventLogEntryType.Information);

                            Trace.WriteLine($"[INFO] Задача \"Учить C#\" успешно добавлена.");

                            Trace.WriteLine("[TRACE] Конец операции AddTask.");
                            break;
                        case "list":


                            var task = taskManagers.ListTasks();
                            Trace.WriteLine($" [INFO] Всего задач: 1.");

                            if (task != null)
                            {
                                if (task.Count() > 0)
                                {

                                    Trace.WriteLine($"{DateTime.Now} Количество задач:{task.Count}");

                                    foreach (var tas in task)
                                    {
                                        Trace.WriteLine($"{DateTime.Now} Количество задач:{tas.Title} {tas.Description} {tas.приоритет}");

                                    }

                                }
                                else
                                {
                                    Trace.WriteLine($"{DateTime.Now} Количество книг:{0}");

                                }

                            }
                            EventLog.WriteEntry("TaskManager", "Выполнилась TaskManager list.", EventLogEntryType.Information);

                            break;
                        case "remove":

                            Trace.WriteLine("[TRACE] Начало операции RemoveTask.");
                            Trace.WriteLine("Введите название задачу для удаления \r\n");
                            TitleBook = Console.ReadLine();
                             var  tasks =   taskManagers.RemoveTask(TitleBook);

                            if(tasks.приоритет == null)
                            {
                                 EventLog.WriteEntry($"TaskManager", $"Задача {TitleBook} не найдена.", EventLogEntryType.Error);
                                Trace.WriteLine($" [ERROR] Задача \"{TitleBook} \" не найдена.");
                                Trace.WriteLine("[TRACE] Конец операции RemoveTask.");                   
                                throw new Exception();

                            }
                            else
                            {

                            } 
                            Trace.WriteLine($"[TRACE] {DateTime.Now} Попытка удалить задачу:\".");

                            Trace.WriteLine($"[LOG] {DateTime.Now} Задача \n удалена.");
                            break;

                        case "exit":
                            infiti = false;
                            Trace.WriteLine($"[INFO] Завершение работы программы..");

                            Trace.Flush();
                            Trace.Close();
                            Environment.Exit(0);
                            break;

                        default:

                            throw new Exception();
                    }
                }
                catch (Exception ex)
                {

                    Trace.WriteLine("Стек вызовов:");
                    Trace.WriteLine(ex.StackTrace); // Трассировка ошибки
                }
            }
        }
    }
}
