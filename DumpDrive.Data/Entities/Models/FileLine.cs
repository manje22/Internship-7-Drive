using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class FileLine
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public File ParentFile { get; set; }
        public string Content { get; set; }

        public FileLine(int fileId, string content)
        {
            Id = fileId;
            Content = content;
        }
    }
}
