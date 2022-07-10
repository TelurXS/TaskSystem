using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    class Task
    {
        public string Type;
        public string Message;
        public DateTime Time;
        public TaskState State;
        
        public Task()
        {
            Type = "SoundAlert";
            Message = null;
            Time = DateTime.Now;
            State = TaskState.Expectation;
        }

        public Task(string message, DateTime date)
        {
            Type = "SoundAlert";
            this.Message = message;
            this.Time = date;
            State = TaskState.Expectation;
        }
    }
}
