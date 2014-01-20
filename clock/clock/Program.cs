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
            DateTime now = DateTime.Now;
            List<Alarms> alarm = new List<Alarms>();
            Console.ForegroundColor = ConsoleColor.White;
            alarm.Add(new Alarms { hour = 8, minute = 0, message = "Start" });
            alarm.Add(new Alarms { hour = 10, minute = 30, message = "First break" });
            alarm.Add(new Alarms { hour = 11, minute = 30, message = "Lunch" });
            alarm.Add(new Alarms { hour = 12, minute = 30, message = "Back to work" });
            alarm.Add(new Alarms { hour = 15, minute = 00, message = "Last break" });
            alarm.Add(new Alarms { hour = 17, minute = 0, message = "Go Home" });

            if (DateTime.Now.Hour <= 17)
            {
                foreach (Alarms alarms in alarm)
                {
                    DateTime alarmed = new DateTime(now.Year, now.Month, now.Day, alarms.hour, alarms.minute, 0);
                    while (now < alarmed)
                    {
                        now = DateTime.Now;
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine(now);
                    }
                    AlarmSound(alarms.message);
                }
            }
            else AlarmSound("It's past time to go home...leave already!");
            char x = ' ';
            while (x != 'q')
            {
                if (Console.KeyAvailable)
                {
                    x = Console.ReadKey(true).KeyChar;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(DateTime.Now);
            }
        }
        public static void AlarmSound(string message)
        {
            Console.Write(message);
            while (!Console.KeyAvailable)
            {
                Console.Beep();
            }
            char x = Console.ReadKey(true).KeyChar;
            Console.Clear();
            return;
        }
    }
}
