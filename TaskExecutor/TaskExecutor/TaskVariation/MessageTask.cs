using JsonSubTypes;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(MessageTask), nameof(MessageTask))]
    public class MessageTask : Task
    {
        public override string Type { get; protected set; } = nameof(MessageTask);


        public MessageTask(string arguments, DateTime executionTime) : base(arguments, executionTime) 
        {
            Icon = Properties.Resources.Latter;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                MessageBox.Show(Arguments, Type, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                State = TaskState.Executed;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }
    }
}
