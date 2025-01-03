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
using DumpDrive.Domain.Enums;

namespace DumpDrive.Presentation.Actions.MainMenu
{
    public class EditProfile : IAction
    {
        private readonly UserRepository _userRepository;
        private User? _user;

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

            var users = _userRepository.GetAll();
            User? user = users.FirstOrDefault(u => u.Email == _user.Email);

            if (user == null)
            {
                Writer.Error("User not found.");
                return;
            }


            string? newEmail = Reader.ReadInput();

            if (string.IsNullOrEmpty(newEmail))
            {
                Writer.Error("Invalid email input.");
                return;
            }


            var newPassword = ActionExtenstions.CorrectPasswordChoice();

            if (!ActionExtenstions.RepeatPassword(newPassword))
            {
                Writer.Error("Passwords do not match.");
                return;
            }

            user.Email = newEmail;
            user.Password = newPassword;

            var updateResult = _userRepository.Update(user, _user.Email);
            if (updateResult == Result.Success)
            {
                Writer.Write("Success");
            }
            else
            {
                Writer.Error("Failed to update profile.");
            }
        }
    }
}
