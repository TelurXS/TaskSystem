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

        public TaskManager()
        {
            Tasks = new List<Task>();
        }

        public void SetTask(string message, DateTime dateTime)
        {
            Tasks.Add(new SoundAlert(message, dateTime));
        }

        public void Save()
        {
            File.WriteAllText(ToPath(), JsonConvert.SerializeObject(Tasks));
        }

        public static TaskManager Load()
        {
            return JsonConvert.DeserializeObject<TaskManager>(File.ReadAllText(ToPath()));
        }

        private static string ToPath()
        {
            return @"../../../Tasks.json";
        }

       
          
    }
}
