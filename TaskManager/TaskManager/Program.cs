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
            while (true)
            {
                Console.WriteLine();

                Console.WriteLine("=======================================");
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Edit task");
                Console.WriteLine("3. Delete task");
                Console.WriteLine("4. Remove Obsolete Tasks");
                Console.WriteLine("5. Show task");
                Console.WriteLine("=======================================");

                string choice = Console.ReadLine();
                TaskManager manager = new TaskManager();
                DefenseFool defenseFool = new DefenseFool();

                switch (choice)
                {
                    case "1":

                        manager.SetTasks(TaskManager.Load());

                        Console.Write("Enter note: ");
                        string message = Console.ReadLine();

                        Console.WriteLine("Enter type:");
                        string type = defenseFool.NewType();

                        DateTime date = defenseFool.NewDate();

                        manager.AddTask(type, message, date);
                        manager.Save();
                        break;

                    case "2":

                        manager.EditTask();
                        break;

                    case "3":

                        manager.DeleteTask();
                        break;

                    case "4":

                        Console.Clear();

                        manager.RemoveObsoleteTasks();
                        break;

                    case "5":

                        manager.SetTasks(TaskManager.Load());
                        Console.Clear();

                        manager.ReadTasks();
                        break;

                    default:

                        Console.WriteLine("You entered an invalid value");
                        Console.Clear();

                        break;

                }
            }
        }
    }
}
