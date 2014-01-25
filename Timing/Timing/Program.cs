using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string exit = "";
            while (exit != "Q")
            {   List<AlarmTime> alarm = new List<AlarmTime>();
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable)
                {
                    exit = InterpretKey();
                    if (exit == "E")
                        alarm = EditAlarmTime(alarm);
                        
                }
                DateTime now = DateTime.Now;
                WriteTime(now.Month, "/");
                WriteTime(now.Day, "/");
                WriteTime(now.Year, "  ");
                WriteTime(now.Hour, ":");
                WriteTime(now.Minute, ":");
                WriteTime(now.Second, "");
            }
            //end of main method
        }

        private static string InterpretKey()
        {
            return Console.ReadKey(true).KeyChar.ToString().ToUpper();
        }

        private static List<AlarmTime> EditAlarmTime(List<AlarmTime> alarm)
        {
            string menuChoice = "";
            bool leaveMenu = false;
            while (!leaveMenu)
            {
                if (alarm.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("A - Add Alarm\nE - Exit");
                    while (!Console.KeyAvailable)
                    {

                    }
                    menuChoice = InterpretKey();
                    switch (menuChoice)
                    {
                        case "A":
                            alarm = AddAlarm(alarm);
                            break;
                        case "E":
                            Console.Clear();
                            leaveMenu = true;
                            break;
                    }
                }
            }
            return alarm;
        }

        private static List<AlarmTime> AddAlarm(List<AlarmTime> alarm)
        {
            int hour = -1, minute = -1;
            while (hour < 0 || hour > 23)
                hour = NumberPrompt("Hour ");
            while (minute < 0 || minute > 59) ;
            minute = NumberPrompt("Minute ");
            
            
            return alarm;
        }

        private static int NumberPrompt(string p)
        {
            throw new NotImplementedException();
        }
        private static void WriteTime(int number, string spacer)
        {
            if (number < 10)
            { 
                Console.Write("0"); 
            }
            Console.Write(number + spacer);
        }
    }
}
