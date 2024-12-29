using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class SharedFolderUser
    {
        public int FolderId { get; set; }
        public Folder Folder { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public SharedFolderUser(int folderId, int userId)
        {
            FolderId = folderId;
            UserId = userId;
        }
    }
}
