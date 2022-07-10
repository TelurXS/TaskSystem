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
            //while (true)
            //{
            //    Console.WriteLine("=======================================");
            //    Console.WriteLine("Select an action:");
            //    Console.WriteLine("1. Create a task");
            //    Console.WriteLine("2. Edit task");
            //    Console.WriteLine("3. Delete task");
            //    Console.WriteLine("4. Show task");
            //    Console.WriteLine("=======================================");

            //    string choice = Console.ReadLine();
            //    TaskManager manager = new TaskManager();
            //    DefenseFool defenseFool = new DefenseFool();


            //    if (choice == "1")
            //    {
            //        manager.SetTasks(TaskManager.Load());  // Loading information from json file

            //        Console.Write("Enter note: ");
            //        string message = Console.ReadLine();

            //        DateTime date = defenseFool.NewDate();

            //        manager.AddTask(message, date);
            //        manager.Save();
            //    }
            //    else if (choice == "2")
            //    {
            //        manager.SetTasks(TaskManager.Load());

            //        Console.Write("Enter note: ");
            //        string oldMessage = Console.ReadLine();

            //        DateTime oldDate = defenseFool.NewDate();

            //        Console.Write("Enter new note: ");
            //        string newMessage = Console.ReadLine();

            //        DateTime newDate = defenseFool.NewDate();

            //        manager.EditTask(oldMessage, oldDate, newMessage, newDate);
            //        manager.Save();
            //    }
            //    else if (choice == "3")
            //    {
            //        manager.SetTasks(TaskManager.Load());

            //        Console.Write("Enter note: ");
            //        string message = Console.ReadLine();

            //        DateTime date = defenseFool.NewDate();

            //        manager.DeleteTask(message, date);
            //        manager.Save();
            //    }
            //    else if (choice == "4")
            //    {
            //        manager.SetTasks(TaskManager.Load());

            //        manager.ReadTasks();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Вы ввели неверное значение!");
            //        Console.Clear();
            //    }
            //}

            TaskManager manager = new TaskManager();
            DateTime dateTime = DateTime.Now;
            manager.AddTask("Pon", dateTime);
            manager.Save();

        }
    }
}
