using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class SharedFileUser
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int FileId { get; set; }
        public File File { get; set; } = null!;

        public SharedFileUser(int userId, int fileId) 
        {
            UserId = userId;
            FileId = fileId;
        }
    }
}
