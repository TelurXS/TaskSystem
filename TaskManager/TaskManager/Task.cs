using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    abstract class Task
    {
        public string Message;
        public DateTime Date;
        public Condition Condition;
        public Task()
        {
            Message = null;
            Date = DateTime.Now;
            Condition = Condition.Expectation;
        }

        public Task(string message, DateTime date)
        {
            this.Message = message;
            this.Date = date;
            Condition = Condition.Expectation;
        }

        public abstract void Execute();
        public abstract bool CanExecute();

    }
}
