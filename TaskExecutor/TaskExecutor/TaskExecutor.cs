using System.Threading.Tasks;
using AsyncTask = System.Threading.Tasks.Task;

namespace TaskExecutor
{
    class TaskExecutor
    {
        public List<Task> Tasks { get; protected set; }
        public int ExecuteDelay { get; protected set; }

        public TaskExecutor(int executeDelay, List<Task> tasks)
        {
            ExecuteDelay = executeDelay;
            Tasks = tasks;
        }

        public async AsyncTask RunAsync() 
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Now: " + DateTime.Now);
                PrintTasks();

                foreach(Task task in Tasks) 
                {
                    task.TryExecute();
                }

                await AsyncTask.Delay(ExecuteDelay * 1000);
            }
        }

        public void PrintTasks() 
        {
            foreach(Task task in Tasks) 
            {
                Console.WriteLine(task);
            }
        }
    }
}
