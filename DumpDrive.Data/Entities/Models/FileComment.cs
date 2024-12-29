using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class FileComment
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public File ParentFile { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public FileComment(int fileId, int userId, string content) 
        {
            FileId = fileId;
            UserId = userId;
            Content = content;
        }

    }
}
