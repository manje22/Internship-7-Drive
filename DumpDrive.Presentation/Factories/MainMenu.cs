using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenu
    {
        public static IList<IAction> CreateActions(User user)
        {
            User _user = user;
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
