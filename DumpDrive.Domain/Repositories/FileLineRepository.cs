using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Repositories
{
    public class FileLineRepository : BaseRepository
    {
        public FileLineRepository(DumpDriveDbContext dbContext) : base(dbContext) { }

        public Result Add(FileLine fileLine)
        {
            DbContext.FileLines.Add(fileLine);

            return SaveChanges();
        }

        public Result Delete(int id)
        {
            var lineToBeDeleted = DbContext.FileLines.Find(id);
            if (lineToBeDeleted is null)
            {
                return Result.NotFound;
            }

            DbContext.FileLines.Remove(lineToBeDeleted);

            return SaveChanges();
        }

        public Result Update(FileLine fileLine, int id)
        {
            var lineToBeUpdated = DbContext.FileLines.Find(id);

            if (lineToBeUpdated is null)
            {
                return Result.NotFound;
            }

            lineToBeUpdated.Content = fileLine.Content;
            lineToBeUpdated.ParentFile.LastChanged = DateTime.UtcNow;

            return SaveChanges();
        }

        public ICollection<FileLine> GetAll(int fileId)
        {
            var fileContent = DbContext.FileLines.Where(f => f.FileId == fileId).ToList();
            return fileContent;
        }
    }
}
