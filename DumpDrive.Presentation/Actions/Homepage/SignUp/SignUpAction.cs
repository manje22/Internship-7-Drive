using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Extentions;
using DumpDrive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Actions.Homepage.SignUp
{
    public class SignUpAction : IAction
    {
        public string Name { get; set; } = "Sign up";
        private readonly UserRepository _userRepository;
        public int MenuIndex { get; set; }

        public SignUpAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.WriteLine("You want to register a new user");

            var email = ActionExtenstions.CorrectEmailChoice();
            var password = ActionExtenstions.CorrectPasswordChoice();
            User? user = _userRepository.GetByEmail(email);

            while(user != null)
            {
                Writer.Error("Vec postoji korisnik");
                email = ActionExtenstions.CorrectEmailChoice();
                password = ActionExtenstions.CorrectPasswordChoice();
            }


            User newUser = new User(email, password);
            _userRepository.Add(newUser);
        }
    }
}
