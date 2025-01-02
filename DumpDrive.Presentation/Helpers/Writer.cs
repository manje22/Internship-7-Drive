using DumpDrive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Helpers
{
    public class Writer
    {

        public static void Write(string output)
        {
            Console.WriteLine(output);
        }
        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void Error(string message, int duration)
        {
            Console.WriteLine(message);
            Thread.Sleep(duration);
            Console.Clear();
        }

        public static void HowShouldYourEmailLook(int number, string where)
        {
            Error($"Your email shoul contain at least {number} letter {where}.");
        }
    }
}
