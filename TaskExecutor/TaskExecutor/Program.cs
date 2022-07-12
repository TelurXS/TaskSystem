
namespace TaskExecutor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Config config = Config.Load(@"../../../Config/Config.json");

            TaskExecutor executor = new TaskExecutor(config);

            TaskVisualizerForm form = new TaskVisualizerForm(executor);

            executor.Run();
            Application.Run(form);
        }
    }
}