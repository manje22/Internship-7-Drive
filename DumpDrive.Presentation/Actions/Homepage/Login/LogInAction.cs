using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Extentions;

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
            User? user = FindUser();

            while (user == null)
            {
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    user = FindUser();
                else
                    ActionExtenstions.PrintActions();
            }

            var successfullLogIn = PasswordValidation(user);

            if (successfullLogIn)
                Console.WriteLine($"Logged in as {user.Email} pass: {user.Password}");
            else
                Writer.Error("Krivo unesena lozinka, povratak na pocetak", 30000);

            ActionExtenstions.PrintMainMenu(user);
        }

        public User? FindUser()
        {
            Console.Clear();

            Reader.TryReadLine("Enter your email: ", out string email);

            User? user = _userRepository.GetByEmail(email);

            return user;
        }

        public bool PasswordValidation(User user)
        {
            Reader.TryReadLine("Enter your password: ", out string password);

            return _userRepository.CheckPassword(user, password);
        }
    }
}
