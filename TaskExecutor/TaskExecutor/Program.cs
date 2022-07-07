
namespace TaskExecutor
{
    class Program
    {
        public static void Main()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Executed 1", DateTime.Now.AddMinutes(1)));
            tasks.Add(new Task("Executed 2", DateTime.Now.AddMinutes(2)));
            tasks.Add(new Task("Executed 3", DateTime.Now.AddMinutes(3)));

            TaskExecutor executor = new TaskExecutor(10, tasks);
            executor.RunAsync().GetAwaiter().GetResult();
        }
    }
}
