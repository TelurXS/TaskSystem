using Newtonsoft.Json;
using AsyncTask = System.Threading.Tasks.Task;

namespace TaskExecutor
{
    public class TaskExecutor
    {
        public List<Task> Tasks { get; protected set; }
        public int ExecuteDelay { get; protected set; }

        public string Path { get; set; }

        public Action<List<Task>>? OnCycleLeave;


        public TaskExecutor(int executeDelay, string path)
        {
            ExecuteDelay = executeDelay;
            Path = path;
            Tasks = new List<Task>();
        }

        public TaskExecutor(Config config)
        {
            ExecuteDelay = config.ExecutionDelay;
            Path = config.DefaultPath;
            Tasks = new List<Task>();
        }

        public async AsyncTask Run() 
        {
            while (true) 
            {                          
                if (TryLoadTasks(out List<Task> tasks)) 
                {
                    Tasks = tasks;

                    foreach (Task task in Tasks)
                    {
                        task.TryExecute();
                    }

                    SaveTasks();
                }

                OnCycleLeave?.Invoke(Tasks);
                await AsyncTask.Delay(ExecuteDelay * 1000);
            }
        }

        public bool TryLoadTasks(out List<Task> tasks) 
        {
            return new TaskParser(Path).TryLoad(out tasks);
        }

        public void LoadTasks() 
        {
            Tasks = new TaskParser(Path).Load();
        }

        public void SaveTasks() 
        {
            new TaskParser(Path).Save(Tasks);
        }
    }
}
