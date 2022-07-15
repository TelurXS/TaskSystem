using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskSystem
{
    internal class TaskManager
    {
        private List<Task> Tasks { get; set; }

        // Create functions
        public TaskManager()
        {
            Tasks = new List<Task>();
        }

        public void AddTask(string types, string arguments, DateTime date)
        {     
            Tasks.Add(new Task(types, arguments, date));
            Console.WriteLine("Success");
        }

        public void SetTasks(List<Task> tasks)
        {
            this.Tasks = tasks;
        }


        // Edit functions

        public void EditTask()
        {
            SetTasks(TaskManager.Load());
            DefenseFool defenseFool = new DefenseFool();

            ReadTasks();

            Console.WriteLine();
            Console.WriteLine("Enter the [Task id] you want to edit: ");
            int idTask = int.Parse(Console.ReadLine());

            if (idTask <= Tasks.LongCount())
            {
                Console.Write("Enter new note: ");
                string argument = Console.ReadLine();

                Console.WriteLine("Enter new type:");
                string type = defenseFool.NewType();

                DateTime time = defenseFool.NewDate();

                Tasks[idTask].Arguments = argument;
                Tasks[idTask].Type = type;
                Tasks[idTask].Time = time;
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("You entered an invalid value");
            }

            Save();
        }


        public void DeleteTask()
        {
            SetTasks(TaskManager.Load());
            ReadTasks();

            Console.WriteLine();
            Console.WriteLine("Enter the [Task id] you want to delete: ");
            int idTask = int.Parse(Console.ReadLine());

            if (idTask <= Tasks.LongCount())
            {
                Tasks.RemoveAt(idTask);
            }
            else
            {
                Console.WriteLine("You entered an invalid value");
            }

            Save();
        }


        public void RemoveObsoleteTasks()
        {
            SetTasks(TaskManager.Load());
            DateTime now = DateTime.Now;
            int remove = 0;

            for (int i = 0; i < Tasks.LongCount(); i++)
            {
                if (Tasks[i].Time < now || Tasks[i].State == TaskState.Performed)
                {
                    Tasks.RemoveAt(i);
                    remove++;
                }
            }
            Console.WriteLine("Removed " + remove + " task(s)");

            Save();
        }


        // Read tasks function
        public void ReadTasks()
        {
            for (int i = 0; i < Tasks.LongCount(); i++)
            {
                Console.WriteLine();

                Console.WriteLine("+++++++++++++++++++++++");
                Console.WriteLine("Task id: " + i);
                Console.WriteLine("Type: " + Tasks[i].Type);
                Console.WriteLine("Message: " + Tasks[i].Arguments);
                Console.WriteLine("Time: " + Tasks[i].Time);
                Console.WriteLine("State: " + Tasks[i].State);
                Console.WriteLine("+++++++++++++++++++++++");
            }
        }


        // Save/Load functions
        public void Save()
        {
            var settings = new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd hh:mm:ss" };
            File.WriteAllText(ToPath(), JsonConvert.SerializeObject(Tasks, Formatting.Indented, settings));
        }

        public static List<Task> Load()
        {
            return JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(ToPath()));
        }

        private static string ToPath()
        {
            return @"../../../Tasks.json";
        }
    }
}
