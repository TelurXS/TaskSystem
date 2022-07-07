using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    abstract class Task
    {
        public string message;
        public DateTime date;

        public Task()
        {
            message = null;
            date = DateTime.Now;
        }

        public Task(string message, DateTime date)
        {
            this.message = message;
            this.date = date;
        }

        public abstract void Execute();
        public abstract bool CanExecute();

    }
}
