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
            
            DateTime dateTime = DateTime.Now;
            
            manager.SetTask("Pon", dateTime);
        }
    }
}
