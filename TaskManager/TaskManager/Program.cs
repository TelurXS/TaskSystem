using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskSystem
{
    class Program
    {
        public static void Main() 
        {
            TaskManager manager = new TaskManager();
            TaskManager manager2 = new TaskManager();

            DateTime dateTime = DateTime.Now;

            manager.SetTask("Pon", dateTime);
            manager.Save();
            manager = TaskManager.Load();
            //manager.SetTask("Gal", dateTime);
            //manager.Save();
        }
    }
}
