using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<FileComment> Comments { get; set; } = new List<FileComment>();
        public ICollection<SharedFileUser> SharedFiles { get; set; } = new List<SharedFileUser>();
        public ICollection<SharedFolderUser> SharedFolders { get; set; } = new List<SharedFolderUser>();
    }
}
