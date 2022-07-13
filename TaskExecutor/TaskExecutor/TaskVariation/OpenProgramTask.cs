using JsonSubTypes;
using System.Diagnostics;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(OpenProgramTask), nameof(OpenProgramTask))]
    public class OpenProgramTask : Task
    {
        public override string Type { get; } = nameof(OpenProgramTask);

        public OpenProgramTask(string arguments, DateTime executionTime) : base(arguments, executionTime)
        {
            Icon = Properties.Resources.Program;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                Process.Start(Arguments);
                State = TaskState.Executed;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }

    }
}
