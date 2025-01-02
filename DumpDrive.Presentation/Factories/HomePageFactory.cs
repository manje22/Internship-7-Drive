using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions.Homepage.Login;
using DumpDrive.Presentation.Actions.Homepage.SignUp;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DumpDrive.Presentation.Factories
{
    public class HomepageFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
            {
            new LogInAction(RepositoryFactory.Create<UserRepository>()),
            new SignUpAction(RepositoryFactory.Create<UserRepository>()),
            new ExitMenuAction(),
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
