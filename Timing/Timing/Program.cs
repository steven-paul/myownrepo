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
            char x = ' ';
            while (x != 'Q' && x != 'q')
            {
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable)
                {
                    x = Console.ReadKey(true).KeyChar;
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
        private static void WriteTime(int number, string spacer)
        {
            if (number < 10)
            { Console.Write("0"); }
            Console.Write(number + spacer);
        }


    }
}
