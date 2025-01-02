using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Actions.Homepage.Login
{
    internal class LogInAction :IAction
    {
        private readonly UserRepository _userRepository;
        public string Name { get; set; } = "Log in";
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public LogInAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {

        }

        public User? FindUser()
        {
            Console.Clear();


        }
    }
}
