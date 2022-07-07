
namespace TaskExecutor
{
    enum TaskState 
    {
        Awaiting,
        Executed
    }

    class Task
    {
        public string Message { get; protected set; }
        public DateTime ExecutionTime { get; protected set; }
        public TaskState State { get; protected set; }


        public Task(string message, DateTime executionTime)
        {
            Message = message;
            ExecutionTime = executionTime;
        }

        public bool CanExecute() 
        {
            DateTime Now = DateTime.Now;

            return 
                (
                    State == TaskState.Awaiting &&
                    Now.Year == ExecutionTime.Year &&
                    Now.Month == ExecutionTime.Month &&
                    Now.Day == ExecutionTime.Day &&
                    Now.Hour == ExecutionTime.Hour &&
                    Now.Minute == ExecutionTime.Minute
                );
        }

        public void Execute() 
        {
            if (State == TaskState.Awaiting)
            {
                Console.WriteLine(Message);
                State = TaskState.Executed;
            }
            else throw new ArgumentException("Task can`t be executed twise");
        }

        public Task Recreate() 
        {
            return new Task(Message, ExecutionTime);
        }

        public bool TryExecute() 
        {
            if (CanExecute())
            {
                Execute();
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"[{ExecutionTime}] Can Execute: {CanExecute()} ({State})";
        }
    }
}
