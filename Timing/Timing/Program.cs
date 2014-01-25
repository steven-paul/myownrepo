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
            {
                List<AlarmTime> alarm = new List<AlarmTime>();
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
        public static string InterpretKey()
        {
            return Console.ReadKey(true).KeyChar.ToString().ToUpper();
        }
        public static List<AlarmTime> EditAlarmTime(List<AlarmTime> alarm)
        {
            string menuChoice = "";
            bool leaveMenu = false;
            while (!leaveMenu)
            {
                if (alarm.Count == 0)
                {   //if no alarms are set
                    Console.Clear();
                    Console.WriteLine("A - Add Alarm\nE - Exit");
                    while (!Console.KeyAvailable)
                    {

                    }
                    menuChoice = InterpretKey();
                    switch (menuChoice)
                    {
                        case "A":
                            // add new alarm
                            alarm = AddAlarm(alarm);
                            break;
                        case "E":
                            //exit from edit alarm menu
                            Console.Clear();
                            leaveMenu = true;
                            break;
                    }
                }
            }
            return alarm;
        }
        public static List<AlarmTime> AddAlarm(List<AlarmTime> alarm)
        {
            int hour = -1, minute = -1;
            while (hour < 0 || hour > 23)
                hour = NumberPrompt("Hour ");
            while (minute < 0 || minute > 59)
                minute = NumberPrompt("Minute ");
            return alarm;
            DateTime now = DateTime.Now;
            if (now.Hour > hour) 
            {
                now.AddDays(1);
            }
            else if (now.Hour==hour && now.Minute > minute)
            {
                now.AddDays(1);
            }
        }
        public static int NumberPrompt(string p)
        {
            bool isNumber = false; int number = 0;
            while (!isNumber)
            {
                Console.Write(p);
                string input = Console.ReadLine();
                isNumber = Int32.TryParse(input, out number);
            } return number;

        }
        public static void WriteTime(int number, string spacer)
        {
            if (number < 10)
            {
                Console.Write("0");
            }
            Console.Write(number + spacer);
        }
    }
}
