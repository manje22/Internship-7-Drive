using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumpDrive.Presentation.Extentions;
using System.Drawing;

namespace DumpDrive.Presentation.Actions.MainMenu
{
    public class EditProfile : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly User? _user;

        public string Name { get; set; } = "Edit profile";
        public int MenuIndex { get; set; }

        public EditProfile(UserRepository userRepository, User? user)
        {
            _userRepository = userRepository;
            _user = user;
        }

        public void Open()
        {
            Console.WriteLine("Edit profile");

            var newEmail = Reader.ReadInput();

            var newPassword = ActionExtenstions.CorrectPasswordChoice();

            if(ActionExtenstions.RepeatPassword(newPassword))
            {
                Console.WriteLine("Successfully edited profile");
                return;
            }

            Writer.Error("Unesene lozinke se ne podudaraju...");
        }
    }
}
