using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    internal class DefenseFool
    {
        public string NewType()
        {
            while (true)
            {
                Console.WriteLine("+++++++++++++++++++++++");
                Console.WriteLine("0. MessageTask");
                Console.WriteLine("1. SoundAlertTask");
                Console.WriteLine("2. OpenProgramTask");
                Console.WriteLine("3. SoundAndMessageTask");
                Console.WriteLine("+++++++++++++++++++++++");

                string numberType = Console.ReadLine();

                switch (numberType)
                {
                    case "0":
                        return "MessageTask";

                    case "1":
                        return "SoundAlertTask";

                    case "2":
                        return "OpenProgramTask";

                    case "3":
                        return "SoundAndMessageTask";

                    default:
                        Console.WriteLine("You have entered an invalid task type.");
                        continue;
                }
            }
        }

        public DateTime NewDate()
        {
            DateTime now = DateTime.Now;

            try
            {
                Console.Write("Enter year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter month: ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Enter day: ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Enter hour: ");
                int hour = int.Parse(Console.ReadLine());

                Console.Write("Enter minute: ");
                int minute = int.Parse(Console.ReadLine());

                DateTime date = new DateTime(year, month, day, hour, minute, 0);

                if (date > now)
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("You entered the wrong date or it is already in the past." +
                        " The date will be entered into the note 10 minutes later than the current one.");
                    now.AddMinutes(10);
                    return now;
                }

            }
            catch
            {
                Console.WriteLine("You entered the wrong date or it is already in the past." +
                    " The date will be entered into the note 10 minutes later than the current one.");
                now.AddMinutes(10);
                return now;
            }  
        }
    }
}