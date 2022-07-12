using Newtonsoft.Json;

namespace TaskExecutor
{
    public class Config
    {
        public static Config Default => new Config(10, @"../../../Tasks.json");

        public static Config Current { get; protected set; } = Default;

        [JsonProperty("ExecutionDelay")] public int ExecutionDelay { get; protected set; }
        [JsonProperty("DefaultPath")] public string DefaultPath { get; protected set; }

        [JsonConstructor]
        protected Config(int delay, string path) 
        {
            ExecutionDelay = delay;
            DefaultPath = path;
        }

        public static Config Load(string path) 
        {
            try
            {
                return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something wrong...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return Default;
            } 
        }

        public void Save(string path) 
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this));
        }
    }
}
