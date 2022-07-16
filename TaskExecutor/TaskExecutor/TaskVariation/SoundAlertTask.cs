using JsonSubTypes;
using System.Media;

namespace TaskExecutor
{
    [JsonSubtypes.KnownSubType(typeof(SoundAlertTask), nameof(SoundAlertTask))]
    public class SoundAlertTask : Task
    {
        public override string Type { get; protected set; } = nameof(SoundAlertTask);


        public SoundAlertTask(string arguments, DateTime executionTime) : base(arguments, executionTime) 
        {
            Icon = Properties.Resources.Speaker;
        }

        public override void Execute()
        {
            if (State == TaskState.Awaiting)
            {
                using (var soundPlayer = new SoundPlayer(Arguments))
                {
                    soundPlayer.Play();
                }
                State = TaskState.Executed;
            }
            else throw new ArgumentException("Task can`t execute twise");
        }
    }
}
