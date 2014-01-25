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
            List<AlarmTime> alarm = new List<AlarmTime>();
            while (exit != "Q")
            {
              
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
                        default:
                            MessagePrint("fuck off");
                            break;
                    }
                }
                else
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
                            // add new alarm
                            alarm = AddAlarm(alarm);
                            break;
                        case "E":
                            //exit from edit alarm menu
                            Console.Clear();
                            leaveMenu = true;
                            break;
                        default:
                            MessagePrint("fuck off");
                            break;
                    }
                }
            }
            return alarm;
        }

        private static void MessagePrint(string p)
        {
            Console.WriteLine(p+"\n<ENTER> to continue");
            Console.ReadLine();
        }
        public static List<AlarmTime> AddAlarm(List<AlarmTime> alarm)
        {   
            int hour = -1, minute = -1;
            while (hour < 0 || hour > 23)
                hour = NumberPrompt("Hour ");
            while (minute < 0 || minute > 59)
                minute = NumberPrompt("Minute ");
            
            DateTime temp = DateTime.Now;
            DateTime now = DateTime.Now;
            if (now.Hour > hour || (now.Hour == hour && now.Minute+5>minute))
            {
                temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, hour, minute, 0);
            }
            else
            {
                temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
            }
            string message = Prompt("Message for alarm?");
            alarm.Add(new AlarmTime { alarms = temp, message=message });
            return alarm;
        }

        private static string Prompt(string p)
        {
            string ans = "";
            while (ans =="")
            {
                Console.WriteLine(p);
                ans = Console.ReadLine();
            } 
            return ans;
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
