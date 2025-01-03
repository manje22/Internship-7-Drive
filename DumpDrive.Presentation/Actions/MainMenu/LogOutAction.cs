using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Extentions;
using DumpDrive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Actions.MainMenu
{
    internal class LogOutAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Log out";

        public LogOutAction() { }

        public void Open()
        {
            Console.Clear();
            Writer.Write("Odjava...");
            ActionExtenstions.PrintActions();
        }
    }
}
