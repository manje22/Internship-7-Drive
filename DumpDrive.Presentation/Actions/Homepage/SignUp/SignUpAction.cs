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

            User? user = _userRepository.GetByEmail(email);

            while (user != null)
            {
                Writer.Error("Vec postoji korisnik");
                email = ActionExtenstions.CorrectEmailChoice();
                user = _userRepository.GetByEmail(email);
            }

            var password = ActionExtenstions.CorrectPasswordChoice();

            while (!ActionExtenstions.RepeatPassword(password))
            {
                Console.WriteLine("unesene lozinke se ne podudaraju");
            }

            if (!ActionExtenstions.CaptchaTest())
            {
                Writer.Error("Krivo unesen string...povratak na pocetak!");
                return;
            }

            User newUser = new User(email, password);
            _userRepository.Add(newUser);


        }
    }
}
