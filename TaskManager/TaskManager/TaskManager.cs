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

        public void AddTask(string message, DateTime date)
        {     
            Tasks.Add(new Task(message, date));
            Console.WriteLine("Success");
        }

        public void SetTasks(List<Task> tasks)
        {
            this.Tasks = tasks;
        }


        // Edit functions
        public void EditTask(string oldMessage, DateTime oldDate, string newMessage, DateTime newDate)
        {
            for (int i = 0; i < Tasks.LongCount(); i++)
            {
                if (Tasks[i].Message == oldMessage && Tasks[i].Time == oldDate) 
                {
                    Tasks[i].Message = newMessage;
                    Tasks[i].Time = newDate;
                    Console.WriteLine("Success");
                    return;
                }
            }
            Console.WriteLine("Task with such data does not exist");
        }

        public void DeleteTask(string message, DateTime date)
        {
            for (int i = 0; i < Tasks.LongCount(); i++)
            {
                if (Tasks[i].Message == message && Tasks[i].Time == date)
                {
                    Tasks.RemoveAt(i);
                    Console.WriteLine("Success");
                    return;
                }
            }
            Console.WriteLine("Task with such data does not exist");
        }


        // Read tasks function
        public void ReadTasks()
        {
            for (int i = 0; i < Tasks.LongCount(); i++)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Message: " + Tasks[i].Message);
                Console.WriteLine("Date: " + Tasks[i].Time);
                Console.WriteLine("=========================");
            }
        }

        // Save/Load functions
        public void Save()
        {
            File.WriteAllText(ToPath(), JsonConvert.SerializeObject(Tasks));
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
