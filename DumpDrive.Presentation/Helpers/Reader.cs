using DumpDrive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DumpDrive.Presentation.Helpers
{
    public class Reader
    {
        public static bool TryReadLine(string message, out string line)
        {
            line = string.Empty;

            Console.WriteLine(message);
            var input = Console.ReadLine();
            var isEmpty = string.IsNullOrWhiteSpace(input);

            if (!isEmpty && input is not null)
                line = input;

            return !isEmpty;
        }

        public static bool TryReadNumber(out int number)
        {
            number = 0;
            var isNumber = int.TryParse(Console.ReadLine(), out var inputNumber);
            if (!isNumber)
                return false;

            number = inputNumber;
            return true;
        }

        public static bool TryReadNumber(string message, out int number)
        {
            Console.WriteLine(message);
            return TryReadNumber(out number);
        }

        public static string TryReadNumberForCategory(string message)
        {
            while (true)
            {
                var input = "";
                do
                {
                    Console.WriteLine(message);
                    input = Console.ReadLine().Trim();
                } while (string.IsNullOrEmpty(input));

                switch (input)
                {
                    case "1":
                        return "1";
                    case "2": return "2";
                    case "3": return "3";
                    case "4": return "4";
                    default: break;
                }
            }
        }

        public static double TryReadDouble(string message)
        {
            Console.WriteLine(message);

            var isNumber = double.TryParse(Console.ReadLine(), out var inputNumber);
            while (!isNumber)
            {
                Console.WriteLine("Molimo da unesete vrijedecu cijenu: ");
                isNumber = double.TryParse(Console.ReadLine(), out inputNumber);
            }
            return inputNumber;
        }


        public static bool BuyerOrMerchant()
        {
            Console.Write("If you want to log in as a buyer press b , if you want to login in as a merchant press m: ");
            var input = Console.ReadLine().ToLower().Trim();
            while (string.IsNullOrEmpty(input) || input != "m" && input != "b")
            {
                Console.WriteLine("Please enter a valid choice");
                input = Console.ReadLine();
            }
            if (input == "m")
                return true;
            return false;
        }
        public static bool DoYouWantToContinue()
        {
            Console.WriteLine("Neispravan unos, ako se zelite vratit stisnite d");
            var input = Console.ReadLine();
            if (input == "d")
                return false;
            return true;
        }

        public static bool Confirmation(string message)
        {
            var input = "";
            do
            {
                Console.WriteLine($"{message} (y/n)");
                input = Console.ReadLine().ToLower().Trim();
            } while (input != "n" && input != "y");

            if (input == "y")
                return true;
            return false;
        }

        public static void ReadInput(string message, out string input)
        {
            Console.WriteLine(message);
            input = Console.ReadLine() ?? string.Empty;
        }


        public static string? ReadInput()
        {
            Console.WriteLine("Enter your choosen email");
            var input = Console.ReadLine();
            string[] inputSplitByMonkey = input.Split('@');
            if (inputSplitByMonkey.Length != 2)
            {
                Writer.Error("Your email shoul contain just one @");
                return null;
            }
            if (inputSplitByMonkey[0].Length < 1)
            {
                Writer.HowShouldYourEmailLook(1, "before @");
                return null;
            }
            string[] inputSplitByTheDot = input.Split(".");
            if (inputSplitByTheDot.Length != 2)
            {
                Writer.Error("Your emial shoul contain just one dot");
                return null;
            }
            if (inputSplitByTheDot[0].Length < 3)
            {
                Writer.HowShouldYourEmailLook(3, "between @ and .");
                return null;
            }
            if (inputSplitByTheDot[1].Length < 2)
            {
                Writer.HowShouldYourEmailLook(2, "after .");
                return null;
            }
            return input;
        }

        public static string ReadInput(string message)
        {
            Console.Write(message);
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Molimo da uneste ne prazan string: ");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
