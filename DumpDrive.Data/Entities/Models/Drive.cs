using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class Drive
    {
        public int Id { get; set; }
        public int Owner_Id { get; set; }
        public ICollection<Folder> Folders { get; set; } = new List<Folder>();

        public Drive(int owner_Id)
        {
           Owner_Id = owner_Id;
        }
    }
}
