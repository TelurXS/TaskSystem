using JsonSubTypes;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(MessageTask), nameof(MessageTask))]
    public class MessageTask : Task
    {
        public override string Type { get; } = nameof(MessageTask);


        public MessageTask(string message, DateTime executionTime) : base(message, executionTime) 
        {
            Icon = Properties.Resources.Latter;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                MessageBox.Show(Message, Type, MessageBoxButtons.OK, MessageBoxIcon.Information);
                State = TaskState.Executed;
                return;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }
    }
}
