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


                if (choice == "1")
                {
                    try
                    {
                        manager.SetTasks(TaskManager.Load());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("json file created");
                    }

                    
                    Console.Write("Enter note: ");
                    string message = Console.ReadLine();

                    Console.WriteLine("Enter type:");
                    string type = defenseFool.NewType();

                    DateTime date = defenseFool.NewDate();

                    manager.AddTask(type ,message, date);
                    manager.Save();
                }

                try
                {
                    manager.SetTasks(TaskManager.Load());
                }
                catch (Exception ex)
                {
                    Console.WriteLine();

                    Console.WriteLine("Please create a task before working with data!");
                    continue;
                }

                if (choice == "2")
                {
                    manager.EditTask();
                }
                else if (choice == "3")
                {
                    manager.DeleteTask();
                }
                else if (choice == "4")
                {
                    manager.RemoveObsoleteTasks();
                }
                else if (choice == "5")
                {
                    manager.SetTasks(TaskManager.Load());

                    manager.ReadTasks();
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    Console.Clear();
                }
            }
        }
    }
}
