using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public int ParentDriveId { get; set; }
        public Drive ParentDrive { get; set; }
        public string Name { get; set; }
        public ICollection<File> Files { get; set; } = new List<File>();
        public ICollection<SharedFolderUser> SharedWith { get; set; } = new List<User>();

        public Folder(int parentDriveId,  string name)
        {
            ParentDriveId = parentDriveId;
            Name = name;
        }
    }
}
