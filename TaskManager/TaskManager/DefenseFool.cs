using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    internal class DefenseFool
    {
        public DateTime NewDate()
        {
            DateTime now = DateTime.Now;

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
    }
}
