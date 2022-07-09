using Newtonsoft.Json;

namespace TaskExecutor
{
    class TaskParser
    {
        public string Path { get; protected set; }

        public TaskParser(string path)
        {
            Path = path;
        }

        public List<Task>? Load() 
        {
            return JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(Path));
        }

        public void Save(List<Task> tasks) 
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(tasks));
        }
    }
}
