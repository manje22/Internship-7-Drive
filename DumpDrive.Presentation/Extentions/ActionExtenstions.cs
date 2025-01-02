using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Extentions
{
    public static class ActionExtenstions
    {
        public static void PrintActionsAndOpen(this IList<IAction> actions)
        {
            const string INVALID_INPUT_MSG = "Please type in number!";
            const string INVALID_ACTION_MSG = "Please select valid action!";


            var isExitSelected = false;
            do
            {
                PrintActions(actions);

                var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
                if (!isValidInput)
                {
                    PrintErrorMessage(INVALID_INPUT_MSG);
                    continue;
                }

                var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
                if (action is null)
                {
                    PrintErrorMessage(INVALID_ACTION_MSG);
                    continue;
                }

                action.Open();

                isExitSelected = action is ExitMenuAction;
            } while (!isExitSelected);
        }

        public static void PrintActions()
        {
            var homepageActions = HomepageFactory.CreateActions();
            homepageActions.PrintActionsAndOpen();
        }

        public static void PrintActions(IList<IAction> actions)
        {
            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }

        private static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void SetActionIndexes(this IList<IAction> actions)
        {
            var index = 0;
            foreach (var action in actions)
            {
                action.MenuIndex = ++index;
            }
        }

        public static string CorrectEmailChoice()
        {
            string? email = Reader.ReadInput();
            while (email == null)
            {
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    email = EmailChoice();
                else
                    PrintActions();
            }
            return email;
        }

        public static string CorrectPasswordChoice()
        {
            string? password = Reader.ReadInput("Unesite lozinku: ");
            return password;
        }

        public static string? EmailChoice()
        {
            Console.Clear();
            string? email = Reader.ReadInput();
            return email;
        }
    }
}
