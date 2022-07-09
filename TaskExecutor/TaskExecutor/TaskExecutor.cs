using Newtonsoft.Json;
using AsyncTask = System.Threading.Tasks.Task;

namespace TaskExecutor
{
    public class TaskExecutor
    {
        public List<Task> Tasks { get; protected set; }
        public int ExecuteDelay { get; protected set; }
        public string TasksPath { get; protected set; }

        public Action<List<Task>>? OnCycleLeave;

        public TaskExecutor(int executeDelay, string path)
        {
            ExecuteDelay = executeDelay;
            TasksPath = path;
            Tasks = new List<Task>();
        }

        public async AsyncTask Run() 
        {
            while (true) 
            {
                LoadTasks();

                foreach(Task task in Tasks) 
                {
                    task.TryExecute();
                }

                SaveTasks();

                OnCycleLeave?.Invoke(Tasks);
                await AsyncTask.Delay(ExecuteDelay * 1000);
            }
        }

        public void LoadTasks() 
        {
            Tasks = new TaskParser(TasksPath).Load();
        }

        public void SaveTasks() 
        {
            new TaskParser(TasksPath).Save(Tasks);
        }

    }
}
