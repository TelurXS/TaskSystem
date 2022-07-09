using Newtonsoft.Json;

namespace TaskExecutor
{
    public enum TaskState
    {
        Awaiting,
        Executed
    }

    public class Task
    {
        [JsonIgnore] public string Type { get; protected set; }
        [JsonIgnore] public Bitmap Icon { get; protected set; }
        [JsonProperty("Message")] public string Message { get; protected set; }
        [JsonProperty("Date")] public DateTime ExecutionTime { get; protected set; }
        [JsonProperty("Condition")] public TaskState State { get; protected set; }

        public Task(string message, DateTime executionTime)
        {
            Type = "Base Task";
            Icon = Properties.Resources.Task;
            Message = message;
            ExecutionTime = executionTime;
            State = TaskState.Awaiting;
        }

        public virtual bool CanExecute() 
        {
            DateTime now = DateTime.Now;

            return
                (
                    State == TaskState.Awaiting &&
                    now.Year == ExecutionTime.Year &&
                    now.Month == ExecutionTime.Month &&
                    now.Day == ExecutionTime.Day &&
                    now.Hour == ExecutionTime.Hour &&
                    now.Minute == ExecutionTime.Minute
                );
        }

        public virtual void Execute() 
        {
            if (State == TaskState.Awaiting)
            {
                MessageBox.Show(Message, Type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                State = TaskState.Executed;
                return;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }

        public virtual bool TryExecute() 
        {
            if (CanExecute()) 
            {
                Execute();
                return true;
            }

            return false;
        }
    }
}
