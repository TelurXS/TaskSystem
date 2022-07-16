using JsonSubTypes;
using Newtonsoft.Json;

namespace TaskExecutor
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    public abstract class Task
    {
        [JsonProperty("Type")] public abstract string Type { get; protected set; }
        [JsonProperty("Arguments")] public string Arguments { get; protected set; }
        [JsonProperty("Time")] public DateTime ExecutionTime { get; protected set; }
        [JsonProperty("Condition")] public TaskState State { get; protected set; }

        [JsonIgnore] public Bitmap Icon { get; protected set; }


        public Task(string arguments, DateTime executionTime)
        {
            Icon = Properties.Resources.Task;
            Arguments = arguments;
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
                MessageBox.Show(Arguments, Type, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                State = TaskState.Executed;
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

        public virtual string ShortDescription(int erraseFromIndex = 44) 
        {
            if (Arguments.Length <= erraseFromIndex)
            {
                return Arguments;
            }
            else
            {
                string result = Arguments.Remove(erraseFromIndex);
                result += "...";
                return result;
            }
        }
    }
}
