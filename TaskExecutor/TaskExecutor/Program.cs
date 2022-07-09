
namespace TaskExecutor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            TaskExecutor executor = new TaskExecutor(10, @"../../../Tasks.json");

            TaskVisualizerForm form = new TaskVisualizerForm(executor);

            executor.Run();
            Application.Run(form);
        }
    }
}