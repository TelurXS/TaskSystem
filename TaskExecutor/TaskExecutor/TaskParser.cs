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

        public bool TryLoad(out List<Task> tasks) 
        {
            if (File.Exists(Path)) 
            {
                try
                {
                    string json = File.ReadAllText(Path);
                    tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                    return true;
                }
                catch
                {
                    tasks = new List<Task>();
                    return false;
                }
            }
            else 
            {
                tasks = new List<Task>();
                return false;
            }
        }

        public List<Task>? Load()
        {
            if (File.Exists(Path))
            {
                try 
                {
                    string json = File.ReadAllText(Path);

                    return JsonConvert.DeserializeObject<List<Task>>(json);
                }
                catch (JsonReaderException ex) 
                {
                    MessageBox.Show("This is not Task file", "Something wrong...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return new List<Task>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something wrong...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return new List<Task>();
                }
            }
            else
            {
                MessageBox.Show($"File ({Path}) is not exsist", "Something wrong...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return new List<Task>();
            }
        }

        public void Save(List<Task> tasks)
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(tasks, Formatting.Indented));
        }
    }
}
