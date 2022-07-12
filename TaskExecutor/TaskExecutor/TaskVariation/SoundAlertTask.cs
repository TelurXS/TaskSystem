using JsonSubTypes;
using System.Media;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(SoundAlertTask), nameof(SoundAlertTask))]
    public class SoundAlertTask : Task
    {
        public override string Type { get; } = nameof(SoundAlertTask);


        public SoundAlertTask(string message, DateTime executionTime) : base(message, executionTime) 
        {
            Icon = Properties.Resources.Speaker;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                using (var soundPlayer = new SoundPlayer(Message))
                {
                    soundPlayer.Play();
                }
                State = TaskState.Executed;
                return;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }
    }
}
