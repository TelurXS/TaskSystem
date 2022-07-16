using JsonSubTypes;
using System.Media;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(SoundAndMessageTask), nameof(SoundAndMessageTask))]
    public class SoundAndMessageTask : Task
    {
        public override string Type { get; protected set; } = nameof(SoundAndMessageTask);

        public SoundAndMessageTask(string arguments, DateTime executionTime) : base(arguments, executionTime)
        {
            Icon = Properties.Resources.Bell;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                string[] arguments = Arguments.Split('|');

                using (var soundPlayer = new SoundPlayer(arguments[0]))
                {
                    soundPlayer.Play();
                }
                MessageBox.Show(arguments[1], Type, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                State = TaskState.Executed;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }
    }
}
