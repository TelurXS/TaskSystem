using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem
{
    internal class SoundAlert : Task
    {
        public SoundAlert(string message, DateTime date) : base(message, date) {  }
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            Console.WriteLine("da");
        }
    }
}
