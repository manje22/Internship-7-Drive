using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChanged { get; set; }
        public ICollection<FileLine> FileLines { get; set; } = new List<FileLine>();
        public ICollection<FileComment> Comments { get; set; } = new List<FileComment>();
        public ICollection<SharedFileUser> SharedWith { get; set; } = new List<SharedFileUser>();

        public File(string name, int folderId)
        {
            Name = name;
            FolderId = folderId;
            Created = DateTime.UtcNow;
        }
    }
}
