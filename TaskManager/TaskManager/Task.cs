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
        public string Arguments;
        public DateTime Time;
        public TaskState State;
        
        public Task()
        {
            Type = null;
            Arguments = null;
            Time = DateTime.Now;
            State = TaskState.Expectation;
        }

        public Task(string type, string arguments, DateTime date)
        {
            this.Type = type;
            this.Arguments = arguments;
            this.Time = date;
            State = TaskState.Expectation;
        }
    }
}
