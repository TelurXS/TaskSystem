using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            Save();
        }

        public void Save()
        {
            File.WriteAllText(ToPath("Tasks"), JsonConvert.SerializeObject(Tasks));
        }

        private static string ToPath(string name)
        {
            return @"../../../" + name + ".json";
        }
    }
}
