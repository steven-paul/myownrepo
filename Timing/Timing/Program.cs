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
            char x = ' ';
            while (x != 'Q')
            {
                if (Console.KeyAvailable)
                {
                    x = Console.ReadKey(true).KeyChar;
                }
                DateTime now = DateTime.Now;
                WriteTime (now.Hour,":");
                WriteTime(now.Minute, ":");
                WriteTime(now.Second, "");
                Console.WriteLine();
                
            }
            //end of main method
        }
        private static void WriteTime(int number, string spacer)
        {
            if (number<10)
            { Console.Write("0"); }
            Console.Write(number+spacer);
        }

      
    }
}
