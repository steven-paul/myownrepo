using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            DateTime now= DateTime.Now;
            List<Alarms> alarm = new List<Alarms>();
            Console.BackgroundColor = ConsoleColor.White;
            alarm.Add(new Alarms { hour = 8, minute = 0 , message ="Start"});
            alarm.Add(new Alarms { hour = 10, minute = 30, message = "First break" });
            alarm.Add(new Alarms { hour = 11, minute = 30, message = "Lunch" });
            alarm.Add(new Alarms { hour = 12, minute = 30, message = "Back to work" });
            alarm.Add(new Alarms { hour = 15, minute = 00, message = "Last break" });
            alarm.Add(new Alarms { hour = 17, minute = 0, message = "Go Home" });
        }
    }
}
